using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	public GameObject[] redShips;
	public GameObject[] greenShips;
	public GameObject[] blueShips;

	private GameObject[] redBases;
	private GameObject[] greenBases;
	private GameObject[] blueBases;

	public static int redCount;
	public static int greenCount;
	public static int blueCount;

	void Awake () {
		greenCount = 0;
		redCount = 0;
	
	}

	void Update()
	{

		StartCoroutine ("CheckingOnStuff");



		greenCount = greenShips.Length + greenBases.Length;
		redCount = redShips.Length + redBases.Length;
		blueCount = blueShips.Length + blueBases.Length;

		//Currently will mark multiple winners once colorCount = 0 is called....
		//green marked out now to allow for replaying battlescene & testing
		if (greenCount == 0 && blueCount == 0) {
			Debug.Log ("Red wins!");
			redCount = 0;
			EnemyAI.isRed = false;
			//EnemyAI.isGreen = false;
			EnemyAI.isBlue = false;
			Application.LoadLevel("menu");
		}

		if (redCount == 0 && greenCount == 0) {
			Debug.Log ("Blue wins!");
			blueCount = 0;
			EnemyAI.isRed = false;
			//EnemyAI.isGreen = false;
			EnemyAI.isBlue = false;
			Application.LoadLevel("menu");
		}
			
		if (redCount == 0 && blueCount == 0) {
			Debug.Log ("Green wins!");
			greenCount = 0;
			EnemyAI.isRed = false;
			//EnemyAI.isGreen = false;
			EnemyAI.isBlue = false;
			Application.LoadLevel("menu");

			
			
		}
	}

	private IEnumerator CheckingOnStuff() {

		while (true) {

			//This is surely expensive and mostly useless information. Perhaps integrate these numbers with EnemyAI findgameobjectswithtag
			greenShips = GameObject.FindGameObjectsWithTag ("Green");
			redShips = GameObject.FindGameObjectsWithTag ("Red");
			blueShips = GameObject.FindGameObjectsWithTag ("Blue");
			
			greenBases = GameObject.FindGameObjectsWithTag ("Green Base");
			redBases = GameObject.FindGameObjectsWithTag ("Red Base");
			blueBases = GameObject.FindGameObjectsWithTag ("Blue Base");

			yield return new WaitForSeconds(.2f);

				}



		}
}
