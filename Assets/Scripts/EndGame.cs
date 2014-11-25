using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	private GameObject[] redShips;
	private GameObject[] greenShips;

	public static int redCount;
	public static int greenCount;

	void Update()
	{
		greenShips = GameObject.FindGameObjectsWithTag ("Green");
		redShips = GameObject.FindGameObjectsWithTag ("Red");

		greenCount = greenShips.Length;
		redCount = redShips.Length;

		if (greenCount == 0) {
			Debug.Log ("Greeeen wins!");
			redCount = 0;
			Application.LoadLevel("menu");
		}
			
			
		if (redCount == 0) {
			Debug.Log ("Redd wins!");
			greenCount = 0;
			Application.LoadLevel("menu");

			
			
		}
	}
}
