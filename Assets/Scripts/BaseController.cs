using UnityEngine;
using System.Collections;

public class BaseController : MonoBehaviour {

	public int baseHitPoints = 300;
	public float delay = 2f;
	public static Color colortest;
	private int red = 0;
	private int green = 0;
	private string friendlyTag;
	private int shipCount;

	public Vector2 thisBasesPosition;

	public int nearbyShips = 0;



	void Start () {

		if (gameObject.tag == "Red Base") {
			friendlyTag = "Red";
		}
		if (gameObject.tag == "Green Base") {
			friendlyTag = "Green";
		}
		if (gameObject.tag == "Blue Base") {
			friendlyTag = "Blue";
		}

		baseHitPoints = 300;
		thisBasesPosition = gameObject.transform.position;
		Debug.Log(friendlyTag + " is located at: " + thisBasesPosition);


		StartCoroutine(CheckingShipCount(1f));


		//Choose Base Color
		if (gameObject.tag == "Red Base") {
			transform.renderer.material.color = hexColor (255, 0, 13, 255);

			
		}
		if (gameObject.tag == "Green Base") {
			transform.renderer.material.color = hexColor (0, 222, 185, 255);
					}
	}

	void Update() {
		if (baseHitPoints < 10) {
			BaseChange ();
		}
		
		if (baseHitPoints < 300) {
			BaseHealth();
		}
	}


	IEnumerator CheckingShipCount(float waitTime){

		Debug.Log ("HEREWJEFLSKDJFSD:LKFJS:DLFKJSD");
		while (true) {

						
						if (gameObject.tag == "Red Base") {
								friendlyTag = "Red";
						}
						if (gameObject.tag == "Green Base") {
								friendlyTag = "Green";
						}
						if (gameObject.tag == "Blue Base") {
								friendlyTag = "Blue";
						}

						Debug.Log (gameObject.tag + " thinks its friendlyTag is: " + friendlyTag);
							
						Collider2D[] shipsArray = Physics2D.OverlapCircleAll (thisBasesPosition, 3f);

						Debug.Log ("there are " + shipsArray.Length + " in shipsArray");

						int i = 0;
						foreach (Collider2D collider in shipsArray) {
				if(collider.gameObject.tag == friendlyTag) { i++; }
										
							Debug.Log ("friendly ship count is: " + shipCount + "shipaArray total is: " + shipsArray.Length);
								}
						shipCount = i;
						
						nearbyShips = i;

						Debug.Log ("DID WE CHECK FOR SHIPS?" + nearbyShips);

				
						yield return new WaitForSeconds (waitTime);
				}
	}


	IEnumerator BaseHealth(){
		yield return new WaitForSeconds(delay);
		baseHitPoints += 10; 
		}

	//this might have the problem if you happened to have five red and five greenships nearby
	void BaseChange () {

		Collider2D[] shipsNearby = Physics2D.OverlapCircleAll(gameObject.transform.position, 2);

		foreach (Collider2D ship in shipsNearby) {
			if (ship.gameObject.tag == "Red") { red++;}
			if (ship.gameObject.tag == "Green") { green++;} 
		}

		Debug.Log("Red: " + red + " &  Green: " + green);

		if (red > green)
		{
			gameObject.tag = "Red Base";
			transform.renderer.material.color = hexColor (255, 0, 13, 255);
		}


		if (green > red)
		{
			gameObject.tag = "Green Base";
			transform.renderer.material.color = hexColor (0, 222, 185, 255);
		}

		baseHitPoints = 150;
		red = 0;
		green = 0;
		}
	
	
	//This is only for converting RGB to proper hexdecimal color, RGB colors can be used below by using hexColor(number, number, number, number)
	public static Vector4 hexColor(float r, float g, float b, float a){
		Vector4 color = new Vector4(r/255, g/255, b/255, a/255);
		colortest = color;
		return color;
	}
}

