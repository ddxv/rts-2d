using UnityEngine;
using System.Collections;

public class Obittwo : MonoBehaviour {
			
		public static GameObject cube;
		static public Transform center;
		public Vector3 axis = Vector2.zero;
		public Vector3 desiredPosition;
		public float radius = 2.0f;
		public float radiusSpeed = 0.5f;
		public float rotationSpeed = 80.0f;
		
		void Start () {
			//cube = GameObject.FindWithTag("Enemy Base");
//			center = cube.transform;
			transform.position = (transform.position - center.position).normalized * radius + center.position;
//			radius = 2.0f;
		}
		
		void Update () {

//
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
//		
//		
//		
//		if (hit != null && hit.collider == null) {
//						//isHit = hit.collider.gameObject.transform.position;
//						Debug.Log ("HITIITITITI");
//						//isHitt = true;
//						//Destroy(GameObject.Find(hit.collider.gameObject.name));

				}


	public void Orbital() {

		center = cube.transform;
		//transform.position = (transform.position - center.position).normalized * radius + center.position;
		radius = 2.0f;



			transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
			desiredPosition = (transform.position - center.position).normalized * radius + center.position;
			transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
		}
	}

