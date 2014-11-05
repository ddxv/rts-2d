using UnityEngine;
using System.Collections;

public class AnyAttack : MonoBehaviour {
	
	private bool attackingbool = false;
	private float delay = 3f;
	private float counter;
	private float dist;
	private float lineDrawSpeed = 10f;
	private LineRenderer lineRenderer;
	private string friendlyShip;
	private string parentBase;
	public Transform origin;
	public Transform destination;
	
	void Start () {
		
		lineRenderer = GetComponent<LineRenderer> ();
		//lineRenderer.SetPosition (0, origin.position);
		lineRenderer.SetWidth (.02f, .02f);

		//Set string with this gameObjects Tag, to use this script on all ships
		friendlyShip = gameObject.tag;

		
		
		
		
	}
	
	
	void Update() {
		
		if (attackingbool == true) {
			lineRenderer.renderer.enabled = true;
			
			origin = this.gameObject.transform;

			//determines distance between attacker and object of attack （destination.position)
			// dist = Vector3.Distance (this.gameObject.transform.position, destination.position);
			
			//LASERS! Should be animated, but doesn't seem to draw, just appear...
			//				if (counter < dist) {
			//						counter += .1f / lineDrawSpeed;
			float x = Mathf.Lerp (0, dist, 1f);
			
			Vector3 pointA = this.gameObject.transform.position;
			Vector3 pointB = origin.position;
			
			// Get the unit Vector in the desired direction, multiply by the desitred length and add a starting point
			Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;
			
			lineRenderer.SetPosition (1, pointAlongLine);
		} else {
			//need to figure out how to remove extra lasers
		}
	}
	
	
	private void OnTriggerEnter2D(Collider2D attackshipg) {

				//Debug.Log ("ship entering collider");

				if (attackshipg.gameObject.tag != friendlyShip & attackshipg.gameObject.tag != "Stuff" & attackshipg.gameObject.tag != "Base") {
		

						Debug.Log (attackshipg.tag + " Attacking Object");

						lineRenderer.SetPosition (0, attackshipg.transform.position);

						attackingbool = true;
						StartCoroutine (Attacking (attackshipg.gameObject));
			
				} else {
						if (attackshipg.gameObject.tag == "Base") { 
								parentBase = attackshipg.gameObject.transform.parent.gameObject.tag;

								if (parentBase == friendlyShip + " Base") {
										//do nothing?
										//Debug.Log ("shouldn't be doing anything now");
								} else {

										Debug.Log (attackshipg.tag + " Attacking Base");
					
										lineRenderer.SetPosition (0, attackshipg.transform.position);
					
										attackingbool = true;
										StartCoroutine (Attacking (attackshipg.gameObject));
								}
						}
						}
				}
	
	IEnumerator Attacking(GameObject shipship) {
		
		
		while (attackingbool == true && shipship != null) {
			
			destination = shipship.transform;
			//origin = this.gameObject.transform.position;
			
			
			//Attacking Other Ships Life Points
			Unit script = shipship.GetComponent<Unit>();
			script.hitPoints -= 10;
			Score.totalPoints += 10;
			Debug.Log ("Current life down," + script.hitPoints);
			if (script.hitPoints < 1) {
				attackingbool = false;
				

				
				
				
			}
			
			yield return new WaitForSeconds(delay);
		}
	}
	
}
