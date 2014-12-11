using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour {

	public Vector3 target;

	public float delay = 3;

	private int friendlyCount = 0;

	private int redEnemyCount;
	private int greenEnemyCount;
	private int blueEnemyCount;

	private int randomBasesShips;

	private string friendlyTag;
	private GameObject enemyBase;

	private string[] enemyTags;
	private string[] enemyBaseTags;

	private GameObject[] allBases;
	private GameObject[] enemyBases;
	private int newWeakest;

	private int baseWithLessShips;
	private int lastShipCount;
	private int minint;

	private GameObject[] friendlyShips;

	private Vector3 weakBaseToAttack;

	private Unit[] startMoves;
	private Obittwo[] startOrbits;

	public static bool isGreen = true;
	public static bool isRed = false;
	public static bool isBlue = false;


	private Transform myTransform;


	void Awake(){
				myTransform = transform;
		}


	void Start() {

		allBases = GameObject.FindGameObjectsWithTag ("Base");

			if (gameObject.tag == "Green Controller" && isGreen == false ) {
				friendlyTag = "Green";
				enemyTags = new string[] {"Red", "Blue"};
				enemyBaseTags = new string[] {"Red Base", "Blue Base", "Enemy Base"};
				
			}
			if (gameObject.tag == "Red Controller" && isRed == false) {
				friendlyTag = "Red";
				enemyTags = new string[] {"Green", "Blue"};
				enemyBaseTags = new string[] {"Green Base", "Blue Base", "Enemy Base"};
				
			}
			
			if (gameObject.tag == "Blue Controller" && isBlue == false) {
				friendlyTag = "Blue";
				enemyTags = new string[] {"Red", "Green"};
				enemyBaseTags = new string[] {"Green Base", "Red Base", "Enemy Base"};
				
		}

		StartCoroutine (Loop ());

	}


	IEnumerator Loop() {
		
		while (true) {


						friendlyCount = GameObject.FindGameObjectsWithTag (friendlyTag).Length;
						allBases = GameObject.FindGameObjectsWithTag ("Base");


						int currentpos = 0;
			minint = 999;


							//checks for base with least amount of ships and sets it to newWeakest
							foreach (GameObject checkingEnemyBase in allBases) {

									if (checkingEnemyBase.gameObject.transform.parent.gameObject.tag != friendlyTag + " Base") {

											BaseController thatBase = checkingEnemyBase.gameObject.transform.parent.gameObject.GetComponent<BaseController> ();

											randomBasesShips = thatBase.nearbyShips;
										if (randomBasesShips == 0) {
											newWeakest = currentpos;
											//break;
											}


										else if (randomBasesShips < minint) { 

												minint = randomBasesShips; 
												newWeakest = currentpos;
											
										}
									}
									currentpos++;
							}

						//attacks base if newWeakest's has less ships than total number of ships
						if (minint < friendlyCount) {

								weakBaseToAttack = allBases [newWeakest].transform.position; 
								enemyBase = allBases [newWeakest].gameObject.transform.parent.gameObject;

								friendlyShips = GameObject.FindGameObjectsWithTag (friendlyTag);
								startOrbits = new Obittwo[friendlyShips.Length];

								Debug.Log ("Computer Moving " + friendlyCount + " " + friendlyTag + " SHIPS!");

								for (int i = 0; i < friendlyShips.Length; i++) {
										friendlyShips [i].GetComponent<Obittwo> ().SetBase (enemyBase);
										friendlyShips [i].GetComponent<Unit> ().StartMove (weakBaseToAttack);
								}
						} 
				

				yield return new WaitForSeconds (delay);
						}
				}

}
