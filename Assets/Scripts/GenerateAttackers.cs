using UnityEngine;
using System.Collections;

public class GenerateAttackers : MonoBehaviour
	
{
	
	public GameObject redShip;
	public GameObject greenShip;
	public GameObject blueShip;
//
//	public GameObject shipShip;

	private float delay=10;
	//public static Color colortest;
	public Vector3 baseLocalPos = Vector3.zero;
	public float baseRadius = 1f;
	public float totalBaseRadius = 2f;
	


//
//	//This is only for converting RGB to proper hexdecimal color, RGB colors can be used below by using hexColor(number, number, number, number)
//	public static Vector4 hexColor(float r, float g, float b, float a){
//		Vector4 color = new Vector4(r/255, g/255, b/255, a/255);
//		colortest = color;
//		return color;
//		
//	}
	
	
	void Start() {
		
				StartCoroutine (Loop ());
	
		}
	
	
	
	IEnumerator Loop() {

		while (true) {

			//this loop checks to find whether ships are enemies or friendly and instantiates them around the base in a random fashion
						if (gameObject.tag == "Green Base") {
							Vector3 pos = FindPos();
							pos += transform.position;
							//Instantiate(prefab, pos, transform.rotation);
							Instantiate(greenShip, pos, Quaternion.identity);
						//	greenShip.transform.renderer.material.color = hexColor (51, 255, 51, 255);

							greenShip.gameObject.tag = "Green";
							
							delay = 2f;
						}
				
						if (gameObject.tag == "Red Base") {
							Vector3 pos = FindPos();
							pos += transform.position;
							//Instantiate(prefab, pos, transform.rotation);
							Instantiate(redShip, pos, Quaternion.identity);
			//	redShip.transform.renderer.material.color = hexColor (255, 0, 0, 255);
			
							redShip.gameObject.tag = "Red";
							delay = 2f;
						}

						if (gameObject.tag == "Blue Base") {
							Vector3 pos = FindPos();
							pos += transform.position;
							//Instantiate(prefab, pos, transform.rotation);
							Instantiate(blueShip, pos, Quaternion.identity);
						//	blueShip.transform.renderer.material.color = hexColor (51, 153, 255, 255);
							blueShip.gameObject.tag = "Blue";
							delay = 2f;
						}
			
			
			
			yield return new WaitForSeconds(delay);
					}
	}



	Vector3 FindPos() {
		Vector3 pos = Vector3.zero;
		pos = Random.insideUnitCircle * totalBaseRadius;
		if (Vector3.Distance(pos, baseLocalPos) > baseRadius) {
		return pos;
			}
		return pos;
	}
	 
		
	}


	