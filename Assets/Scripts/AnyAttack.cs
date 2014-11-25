using UnityEngine;
using System.Collections;

public class AnyAttack : MonoBehaviour {
	
	private bool attackingbool = false;
	private float delay = 1f;
	private float counter;
	private float dist;
	public float distFrom;
	private float lineDrawSpeed = 10f;
	private LineRenderer lineRenderer;
	private string friendlyShip;
	private string friendlyBase;
	private string parentBase;
	public Transform origin;
	public Transform destination;
	
	void Start () {
		
		lineRenderer = GetComponent<LineRenderer> ();
		//lineRenderer.SetPosition (0, origin.position);
		lineRenderer.SetWidth (.02f, .02f);

		//Set string with this gameObjects Tag, to use this script on all ships
		friendlyShip = gameObject.tag;
		friendlyBase = gameObject.tag + " Base";

	}
	
	
	void Update() {


		
		if (attackingbool == true) {
			lineRenderer.enabled = true;
			//lineRenderer.renderer.enabled = true;
			
			origin = this.gameObject.transform;





			//LASERS! Should be animated, but doesn't seem to draw, just appear...
			//				if (counter < dist) {
			//						counter += .1f / lineDrawSpeed;
			float x = Mathf.Lerp (0, dist, 1f);
			
			Vector3 pointA = this.gameObject.transform.position;
			Vector3 pointB = origin.position;
			
			// Get the unit Vector in the desired direction, multiply by the desitred length and add a starting point
			Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;
			
			lineRenderer.SetPosition (1, pointAlongLine);

			//determines distance between attacker and object of attack （destination.position)
			distFrom = Vector3.Distance (pointA, pointB);
			if (distFrom > 2.3) { attackingbool = false; }

		} else {

			lineRenderer.enabled = false;
			//lineRenderer.renderer.enabled = false;
			//need to figure out how to remove extra lasers
		}
	}
	
	
	private void OnTriggerEnter2D(Collider2D objectofattack) {

				//To determine if it is an enemy Ship
				if (objectofattack.gameObject.tag != friendlyShip & objectofattack.gameObject.tag != "Stuff" & objectofattack.gameObject.tag != "Base") {
						attackingbool = true;
						Debug.Log (objectofattack.tag + " Attacking Object");
						lineRenderer.SetPosition (0, objectofattack.transform.position);
						StartCoroutine (Attacking (objectofattack.gameObject));
			
				} else {
						if (objectofattack.gameObject.tag == "Base") { 
								parentBase = objectofattack.gameObject.transform.parent.gameObject.tag;

								if (parentBase == friendlyShip + " Base") {
									attackingbool = false;
								} else {

										//Process of elimination says this game object is an enemybase, so attack.
										attackingbool = true;
										Debug.Log ( " Attacking " + objectofattack.tag);
										lineRenderer.SetPosition (0, objectofattack.transform.position);
										StartCoroutine (AttackingBase (objectofattack.gameObject));
								}
						}
						}
				}
	
	IEnumerator Attacking(GameObject objectofattacktwo) {

		while (objectofattacktwo.gameObject.tag != "Base" && attackingbool == true && objectofattacktwo != null) {


			//attackingbool = true;
			destination = objectofattacktwo.transform;
		
			//Attacking Other Ships Life Points
			Unit script = objectofattacktwo.GetComponent<Unit>();
			script.hitPoints -= 10;
			Score.totalPoints += 10;
			Debug.Log ("Current life down," + script.hitPoints);

			if (script.hitPoints < 1) {
				attackingbool = false;
				}

			yield return new WaitForSeconds(delay);
		}
	}



	//For attacking any bases not friendly Bases
	IEnumerator AttackingBase(GameObject objectofattacktwo) {
		BaseController hp = objectofattacktwo.gameObject.transform.parent.gameObject.GetComponent<BaseController>();
		//attackingbool = true;

		Debug.Log (parentBase + "is parent base and this is ooa" + objectofattacktwo.gameObject.transform.parent.gameObject.tag);

		while ( friendlyBase != objectofattacktwo.gameObject.transform.parent.gameObject.tag && attackingbool == true && hp.baseHitPoints > 0 && objectofattacktwo != null) {

			Debug.Log (friendlyShip + " Dropping Base life down");

				hp.baseHitPoints -= 10;

			if (hp.baseHitPoints < 10) {
				attackingbool = false;


			}

				yield return new WaitForSeconds(delay);
			}
		}











	private void OnTriggerExit2D(Collider2D objectofattack) {

	//	lineRenderer.renderer.enabled = false;
	//if (objectofattack.gameObject.tag == friendlyShip | objectofattack.gameObject.tag == "Base") {
			//			attackingbool = false;
			//	}
		}

	
}
