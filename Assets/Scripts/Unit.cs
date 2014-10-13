using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	protected bool moving, rotating;
	
	private Vector3 destination;
	private Vector3 hitPoint;
	private Quaternion targetRotation;

	public float moveSpeed, rotateSpeed;

	 void Update () {

		if (Input.GetMouseButtonDown (0)) {
						hitPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						hitPoint.z = transform.position.z;
										
						//transform.position = Vector3.MoveTowards(transform.position, hitPoint, 2 * Time.deltaTime);
				
						float x = hitPoint.x;
						float y = hitPoint.y;
						float z = 0;
						Vector3 destination = new Vector3 (x, y, z);
						StartMove (destination);

			//This is currently working, by itself, to rotate ships, problem is they are not pointing correctly (sideways)
						Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);
				}
	  
		if(rotating) TurnToTarget();
		else if(moving) MakeMove();
			}



	public void StartMove(Vector3 destination) {
		Debug.Log ("startmove started");
		this.destination = destination;
		//targetRotation = Quaternion.LookRotation (destination - transform.position);
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
		Debug.Log ("makemove's transforming");
		if(transform.position == destination) moving = false;
	}
	
}

