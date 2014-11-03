using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

		protected bool moving, rotating;
		public int hitPoints = 100;
		private Vector3 destination;
		private Vector3 hitPoint;
		private Vector2 rotateRange;
		public Vector3 targetLocation;
		private int speed = 2;
		private GameObject target;
		Obittwo orbit;
		public static Color colortest;


	

		void Start ()
		{
				orbit = GetComponent<Obittwo> (); 


		}




		void Update ()
		{

				// When the user clicks the mouse button
				if (Input.GetMouseButtonDown (0)) {
						// create and cast a ray at the position of the click
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
						
						// If the ray hits a base, store the base in the unit's base property
						if (hit != null && hit.collider != null && hit.collider.tag == "Base") {
								orbit.SetBase (hit.collider.gameObject);
						} else { // if the position was not an enemy base, detach the unit from it's current base
								orbit.DetachBase ();
						}

						// Get click location for destination
						hitPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						
						float x = hitPoint.x;
						float y = hitPoint.y;
						float z = 0;

						Vector3 destination;
						destination = new Vector3 (x, y, z);
				
			//Move your ships
			if (gameObject.tag == "Green"){
						StartMove (destination);
						// Rotates Ships
						Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);
			}



		}

				if (hitPoints < 1) { Destroy (gameObject); }

				// If the unit is in orbit, then the orbit dermines it's position/rotation so stop movement.
				if (orbit.inOrbit)
						moving = false;
				if (rotating) //rotating ship first using bool, then moving
						TurnToTarget ();
				else if (moving)
						MakeMove ();
		}

		public void StartMove (Vector3 destination)
		{
				Debug.Log ("startmove started");

		//rotates ships ONLY AI, targetLocation set by EnemyAI
		//targetLocation = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation (Vector3.forward, targetLocation - transform.position);
				this.destination = destination;
				rotating = true;
				moving = false;
		}
	
		private void TurnToTarget ()
		{

				// Make sure ship rotates first
				rotating = false;
				moving = true;
		}

		private void MakeMove ()
		{
				transform.position = Vector3.MoveTowards (transform.position, destination, Time.deltaTime * 3);
				//Debug.Log ("makemove's transforming");
				if (transform.position == destination)
						moving = false;
		}
	
}

