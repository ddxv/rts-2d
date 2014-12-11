using UnityEngine;
using System.Collections;

public class BaseController : MonoBehaviour {

	public int baseHitPoints = 300;
	public float delayHealth = 2f;
	private float waitTimeCheck = 1f;
	private int red = 0;
	private int green = 0;
	private int blue = 0;
	private string friendlyTag;
	private int shipCount;

	public Vector2 thisBasesPosition;

	public int nearbyShips = 0;

	public static Color colortest;


	//This is only for converting RGB to proper hexdecimal color, RGB colors can be used below by using hexColor(number, number, number, number)
	public static Vector4 hexColor(float r, float g, float b, float a){
		Vector4 color = new Vector4(r/255, g/255, b/255, a/255);
		colortest = color;
		return color;
		
	}
	//public Score score;



	void Start () {

		if (gameObject.tag == "Red Base") {
			friendlyTag = "Red";			
			transform.renderer.material.color = hexColor (255, 0, 0, 255);


		}
		if (gameObject.tag == "Green Base") {
			friendlyTag = "Green";
			transform.renderer.material.color = hexColor (51, 255, 51, 255);

		}
		if (gameObject.tag == "Blue Base") {
			friendlyTag = "Blue";
			transform.renderer.material.color = hexColor (51, 153, 255, 255);

		}

		baseHitPoints = 300;
		thisBasesPosition = gameObject.transform.position;
		Debug.Log(friendlyTag + " is located at: " + thisBasesPosition);


		StartCoroutine(CheckingShipCount());


	}

	void Update() {
		if (baseHitPoints < 10) {
			BaseChange ();
		}
		
		if (baseHitPoints < 300) {
			BaseHealth();
		}
	}


	IEnumerator CheckingShipCount(){

		while (true) {

						//Debug.Log (gameObject.tag + " thinks its friendlyTag is: " + friendlyTag);


						while (gameObject.tag != "Enemy Base") {

						
								if (gameObject.tag == "Red Base") {
										friendlyTag = "Red";
								}
								if (gameObject.tag == "Green Base") {
										friendlyTag = "Green";
								}
								if (gameObject.tag == "Blue Base") {
										friendlyTag = "Blue";
								}

//								Debug.Log (gameObject.tag + " thinks its friendlyTag is: " + friendlyTag);
							
								Collider2D[] shipsArray = Physics2D.OverlapCircleAll (thisBasesPosition, 3f);

								//Debug.Log ("there are " + shipsArray.Length + " in shipsArray");

								int i = 0;
								foreach (Collider2D collider in shipsArray) {
										if (collider.gameObject.tag == friendlyTag) {
												i++;
										}
										
										//Debug.Log ("Just Completed  a foreach and friendly ship count is: " + i + "and shipaArray total is: " + shipsArray.Length);
								}

								//number is divided by two because ship prefabs currently have two colliders
								shipCount = i / 2;
						
								//number is divided by two because ship prefabs currently have two colliders
								nearbyShips = i / 2;

								//Debug.Log ("Just Completed the Entire foreach loop & there are now " + shipsArray.Length + " in shipsArray" + " and " + nearbyShips + " nearby friendly ships");

				
								yield return new WaitForSeconds (waitTimeCheck);
						}

						yield return new WaitForSeconds (waitTimeCheck);
				}
	}


	IEnumerator BaseHealth(){
		yield return new WaitForSeconds(delayHealth);
		baseHitPoints += 10; 
		}



	//this might have the problem if you happened to have five red and five greenships nearby
	void BaseChange () {

		Collider2D[] shipsNearby = Physics2D.OverlapCircleAll(gameObject.transform.position, 2);



		foreach (Collider2D ship in shipsNearby) {
			if (ship.gameObject.tag == "Red") { red++;}
			if (ship.gameObject.tag == "Green") { green++;}
				if (ship.gameObject.tag == "Blue") { blue++;}  

		}

		Debug.Log("Red: " + red + " &  Green: " + green);

		if (red > green && red > blue)
		{
			gameObject.tag = "Red Base";
			transform.renderer.material.color = hexColor (255, 0, 0, 255);
		}


		if (green > red && green > blue)
		{
			gameObject.tag = "Green Base";
			transform.renderer.material.color = hexColor (51, 255, 51, 255);
		}

		if (blue > green && blue > red)
		{
			gameObject.tag = "Blue Base";
			transform.renderer.material.color = hexColor (51, 153, 255, 255);
		}

		baseHitPoints = 150;
		red = 0;
		green = 0;
		blue = 0;

		GameObject go = GameObject.Find ("_GameController");
		go.GetComponent<Score>().CheckBaseNumbers ();
	

		}
	

}

