using UnityEngine;
using System.Collections;

public class Obittwo : MonoBehaviour
{
			
		public GameObject currentBase;
		public Vector3 axis = Vector2.zero;
		public Vector3 desiredPosition;
		public float radius = 1.5f;
		public float radiusSpeed = 1.5f;
		public float rotationSpeed = 80.0f;

		public bool inOrbit = false;
		
		Transform center;
		float radiusOffset;

		public void SetBase (GameObject newBase)
		{
				currentBase = newBase;
		}

		public void DetachBase ()
		{
				currentBase = null;
		}

		void Start ()
		{
			// Gives each unit a little amount of random offset from the center so they
			// don't all rotate around the exact same circle. Value is negative so they are 
			// closer than the radius
			radiusOffset = Random.Range (0.8f, 0.9f);

		}
		
		void Update ()
		{		
				// If the current base is set, determine if the unit is within it's orbit (based on radius)
				// and set the inOrbit value
				if (currentBase != null) {
						float distance = Vector3.Distance (currentBase.transform.position, transform.position);
						if (distance <= radius)
								inOrbit = true;
						else
								inOrbit = false;	
				} else // If no base, not in orbit
						inOrbit = false;

				// If orbiting, call the orbital method to rotate ship around the base
				if (inOrbit ==  true)
					Orbital ();
		}

		public void Orbital ()
		{				
				center = currentBase.transform;
				print ("orbiting");

				// Rotates the ship around the base
				transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
				
				// If the ship is not at the desired distance from the base, this adjusts the position over time.
				// This is necessary is the unit is too close, or within the radius but not within the offset. 
				desiredPosition = (transform.position - center.position).normalized * radius * radiusOffset + center.position;
				transform.position = Vector3.MoveTowards (transform.position, desiredPosition, Time.deltaTime * radiusSpeed);

				// Angle the ship toward the base.
				transform.rotation = Quaternion.LookRotation (Vector3.forward, currentBase.transform.position - transform.position);

	
		}
}

