using UnityEngine;
using System.Collections;

public class AnyAttack : MonoBehaviour
{
	
		public bool attackingBool = false;
		private float delay = .1f;
		private float counter;
		private string friendlyShip;
		private string friendlyBase;
		private string parentBase;

		//Line Renderer
		public Transform origin;
		public Transform destination;
	
		void Start ()
		{
		

				//Set string with this gameObjects Tag, to use this script on all ships
				friendlyShip = gameObject.tag;
				friendlyBase = gameObject.tag + " Base";

		}
	
		void Update ()
		{

		}
	
		private void OnTriggerEnter2D (Collider2D objectofattack)
		{

				//To determine if it is an enemy Ship
				if (objectofattack.gameObject.tag != friendlyShip & objectofattack.gameObject.tag != "Stuff" & objectofattack.gameObject.tag != "Base" && attackingBool != true) {
						attackingBool = true;
						Debug.Log (objectofattack.tag + " Attacking Object");

						transform.GetComponentInChildren<LaserRender> ().pointThat = objectofattack.gameObject.transform.position;

						StartCoroutine (Attacking (objectofattack.gameObject));
			
				} else {

						//Make sure this isnt a friendlybase
						if (objectofattack.gameObject.tag == "Base" & attackingBool != true) { 
								parentBase = objectofattack.gameObject.transform.parent.gameObject.tag;

								if (parentBase == friendlyShip + " Base") {

									attackingBool = false;
								} else {

										//Process of elimination says this game object is an enemybase, so attack.
										attackingBool = true;
										Debug.Log (" Attacking " + objectofattack.tag);
										gameObject.BroadcastMessage ("FireLaser", objectofattack.gameObject);
										//transform.GetComponentInChildren<LaserRender> ().pointThat = objectofattack.gameObject.transform.position;
										StartCoroutine (AttackingBase (objectofattack.gameObject));
								}
						}
				}
		}
	
		IEnumerator Attacking (GameObject objectofattacktwo)
		{

				while (objectofattacktwo != null && objectofattacktwo.gameObject.tag != "Base" && attackingBool == true) {


						//attackingBool = true;
						destination = objectofattacktwo.transform;
		
						//Attacking Other Ships Life Points
						Unit script = objectofattacktwo.GetComponent<Unit> ();
						script.hitPoints -= 1;

						if (script.hitPoints < 1) {
								attackingBool = false;
						}

						yield return new WaitForSeconds (delay);
				}
		}



		//For attacking any bases not friendly Bases
		IEnumerator AttackingBase (GameObject objectofattacktwo)
		{
				BaseController hp = objectofattacktwo.gameObject.transform.parent.gameObject.GetComponent<BaseController> ();
				//attackingBool = true;

				while (friendlyBase != objectofattacktwo.gameObject.transform.parent.gameObject.tag && attackingBool == true && hp.baseHitPoints > 0 && objectofattacktwo != null) {


						hp.baseHitPoints -= 1;
						yield return new WaitForSeconds (delay);
				}

				if (friendlyBase == objectofattacktwo.gameObject.transform.parent.gameObject.tag) {
						Debug.Log ("This BASE IS OURS WHY NOT STOP?");
						attackingBool = false;
						gameObject.BroadcastMessage ("StopLaser", false);
						
				}
		}
}	

