using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	protected bool moving, rotating;
	
	private Vector3 destination;
	private Vector3 hitPoint;


	private Vector2 rotateRange;
	private int speed = 2;

	private GameObject target;


	

	void Update () {


       
			if (Input.GetMouseButtonDown (0)) {

//			if (Orbit.isHitt == true){
//				StartOrbit(); }
			//transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime );

//						
//				if (Orbit.isHit == true){
//				transform.RotateAround (GameObject.Find(Orbit.collider.gameObject.name)transform.position, Vector3.up, 20 * Time.deltaTime);
//			//transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime );
//			}
//			GameObject.Find(hit.collider.gameObject.name)

						//get click location for destination
						hitPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
										
						float x = hitPoint.x;
						float y = hitPoint.y;
						float z = 0;
						
						Vector3 destination = new Vector3 (x, y, z);
						
						
						StartMove (destination);

						//Rotates Ships
						Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);
				}
	  			
				//rotating ship first using bool, then moving
				if(rotating) TurnToTarget();
				else if(moving) MakeMove();
			}


		public void StartOrbit() {
		Debug.Log ("Did we make it?");
	//	transform.RotateAround (Orbit.isHit, Vector3.up, 20 * Time.deltaTime);
	}



	public void StartMove(Vector3 destination) {
		Debug.Log ("startmove started");
		this.destination = destination;
		rotating = true;
		moving = false;
	}


	
	
	private void TurnToTarget() {

		//make sure ship rotates first
		rotating = false;
		moving = true;
	}




	private void MakeMove() {
		transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 3);
		//Debug.Log ("makemove's transforming");
		if(transform.position == destination) moving = false;
	}
	
}

