using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

		public bool moving, rotating;
		public int hitPoints = 100;
		private string playerTag = "Green";
		private Vector3 destination;
		private Vector2 hitPoint;
		private Vector2 rotateRange;
		public Vector3 targetLocation;
		private int speed = 2;
		private GameObject target;
		Obittwo orbit;
		public static Color colortest;

		void Start ()
		{
				orbit = gameObject.GetComponent<Obittwo> (); 


		if (gameObject.tag == "Green") {
	//	StartCoroutine (PlayerUpdate());
		}

		}

	void Update() {

						if (Input.touchCount == 1 | Input.GetMouseButtonDown (0)) {
								// create and cast a ray at the position of the click
								Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
								RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
			
								// If the ray hits a base, store the base in the unit's base property
								if (hit != null && hit.collider != null && hit.collider.tag == "Base") {
				
										//Sends Message to animate the base when clicked
										hit.collider.gameObject.transform.parent.gameObject.SendMessage ("BaseSelect");
				
										orbit.SetBase (hit.collider.gameObject);
				
								} else { // if the position was not an enemy base, detach the unit from it's current base
										orbit.DetachBase ();
								}
			
								// Get click location for destination
								hitPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			
								//Move your ships
								if (gameObject.tag == playerTag) {
										StartMove (hitPoint);
										// Rotates Ships
										Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
										transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);
								}
			
						}
		
						if (hitPoints < 1) { 
								Score.shipsDestroyed += 1;
			
								Destroy (gameObject); 
			
						}
		
						// If the unit is in orbit, then the orbit dermines it's position/rotation so stop movement.
						if (orbit.inOrbit)
								moving = false;
						if (rotating) //rotating ship first using bool, then moving
								TurnToTarget ();
						else if (moving)
								MakeMove ();

				



	}

//		void Update ()
//		{
//
////CHECK WHAT BASESELECT IS AND WHAT SETBASE
//
//				if (Input.touchCount == 1 | Input.GetMouseButtonDown (0)) {
//						// create and cast a ray at the position of the click
//						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//						RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
//						
//						// If the ray hits a base, store the base in the unit's base property
//						if (hit != null && hit.collider != null && hit.collider.tag == "Base") {
//								
//							//Sends Message to animate the base when clicked
//							hit.collider.gameObject.transform.parent.gameObject.SendMessage ("BaseSelect");
//
//								orbit.SetBase (hit.collider.gameObject);
//
//						} else { // if the position was not an enemy base, detach the unit from it's current base
//								orbit.DetachBase ();
//						}
//
//						// Get click location for destination
//						hitPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//				
//						//Move your ships
//						if (gameObject.tag == playerTag) {
//								StartMove (hitPoint);
//								// Rotates Ships
//								Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//								transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);
//						}
//
//				}
//
//				if (hitPoints < 1) { 
//						Score.shipsDestroyed += 1;
//
//						Destroy (gameObject); 
//						
//				}
//
//				// If the unit is in orbit, then the orbit dermines it's position/rotation so stop movement.
//				if (orbit.inOrbit)
//						moving = false;
//				if (rotating) //rotating ship first using bool, then moving
//						TurnToTarget ();
//				else if (moving)
//						MakeMove ();
//		}

		public void StartMove (Vector3 receiveddest)
		{
				targetLocation = receiveddest;
				transform.rotation = Quaternion.LookRotation (Vector3.forward, targetLocation - transform.position);
				this.destination = receiveddest;
				rotating = true;
				moving = false;

				//Debug.Log ("Checking StartMove and moving is " + moving + " and rotating is " + rotating );

		}
	
		private void TurnToTarget ()
		{

				//Debug.Log ("METHOD TurnToTarget ABOUT TO SET ROTATING FALSE & MOVING TRUE, Moving currently is " + moving + " rotating is " + rotating);

				// Make sure ship rotates first
				rotating = false;
				moving = true;


		}

		private void MakeMove ()
		{
				transform.position = Vector3.MoveTowards (transform.position, destination, Time.deltaTime * 3);
				//Debug.Log ("Checking MakeMove and moving is " + moving);
				if (transform.position == destination)
						moving = false;
		}
	
}

