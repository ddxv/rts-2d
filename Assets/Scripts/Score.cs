using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int shipsDestroyed = 0;
	public static int totalPoints = 0;

	private GameObject[] allBases;

	private int checkingGreenBases = 0;
	private int checkingRedBases = 0;
	private int checkingBlueBases = 0;

	public static int redBases;
	public static int greenBases;
	public static int blueBases;

	void onAwake () {

		shipsDestroyed = 0;
		totalPoints = 0;
		greenBases = 0;
		redBases = 0;
		blueBases = 0;

		checkingRedBases = 0;
		checkingGreenBases = 0;
	
	}

	// Use this for initialization
	void Start () {
		CheckBaseNumbers ();
		}


	public void CheckBaseNumbers(){


	//	Debug.Log ("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

		allBases = GameObject.FindGameObjectsWithTag ("Base");


		checkingRedBases = 0;
		checkingGreenBases = 0;
		checkingBlueBases = 0;

		foreach (GameObject bases in allBases) {
			if (bases.gameObject.transform.parent.gameObject.tag == "Red Base") {
				checkingRedBases++;
			}else if (bases.gameObject.transform.parent.gameObject.tag == "Green Base") {
				checkingGreenBases++;
			}else if (bases.gameObject.transform.parent.gameObject.tag == "Blue Base") {
				checkingBlueBases++;
			}
				}
				
		redBases = checkingRedBases;
		greenBases = checkingGreenBases;
		blueBases = checkingBlueBases;
	}

}
