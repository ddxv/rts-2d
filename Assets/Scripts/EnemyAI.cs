using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour {

	public Vector3 target;

	public float delay = 3;

	private int friendlyCount = 0;

	private int redShipCount;
	private int greenShipCount;
	private int blueShipCount;

	private bool currentlyAttacking;

	private int randomBasesShips;

	private string friendlyTag;
	private GameObject enemyBase;

	private string[] enemyTags;
	private string[] enemyBaseTags;

	private GameObject[] allBases;
	private GameObject[] enemyBases;
	private GameObject[] shipBases;
	private GameObject[] distBases;
	private int newWeakest;

	private int baseWithLessShips;
	private int lastShipCount;

	private GameObject[] friendlyShips;

	private Vector3 weakBaseToAttack;
	private string friendlyBaseTag;
	private GameObject friendlyBase;

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
				friendlyBaseTag = "Green Base";
				enemyTags = new string[] {"Red", "Blue"};
				enemyBaseTags = new string[] {"Red Base", "Blue Base", "Enemy Base"};
				
			}
			if (gameObject.tag == "Red Controller" && isRed == false) {
				friendlyTag = "Red";
				friendlyBaseTag = "Red Base";
				enemyTags = new string[] {"Green", "Blue"};
				enemyBaseTags = new string[] {"Green Base", "Blue Base", "Enemy Base"};
				
			}
			
			if (gameObject.tag == "Blue Controller" && isBlue == false) {
				friendlyTag = "Blue";
				friendlyBaseTag = "Blue Base";
				enemyTags = new string[] {"Red", "Green"};
				enemyBaseTags = new string[] {"Green Base", "Red Base", "Enemy Base"};
				
		}


		allBases = GameObject.FindGameObjectsWithTag ("Base");


		StartCoroutine (Loop ());

	}



	IEnumerator Loop ()
		{
		
				while (true) {


					friendlyCount = GameObject.FindGameObjectsWithTag (friendlyTag).Length;
					friendlyBase = GameObject.FindGameObjectWithTag (friendlyBaseTag);

					if (friendlyTag == "Blue") {  blueShipCount = friendlyCount; }
					if (friendlyTag == "Red") { redShipCount = friendlyCount; }
			
					if (friendlyTag == "Green") { greenShipCount = friendlyCount; }
			
		

						int currentpos = 0;

						//Sorting array based on number of Ships Nearby
						Array.Sort (allBases, (a, b) => {
								// Do compare code here. a and b are two objects being compared to
								// the result must be
								// 1, if a > b
								// 0, if a == b
								// -1, if a < b


								int thatBaseAShips = ((GameObject)a).gameObject.transform.parent.gameObject.GetComponent<BaseController> ().nearbyShips;
								int thatBaseBShips = ((GameObject)b).gameObject.transform.parent.gameObject.GetComponent<BaseController> ().nearbyShips;
				
								if (thatBaseAShips > thatBaseBShips) {
										return 1;
								} else if (thatBaseAShips < thatBaseBShips) {
										return -1;
								}
								return 0;
			
						});


						//resorting the same Array by distance from friendlyBase which is set each loop so could change...
						Array.Sort (allBases, (a, b) => {
								Vector3 distanceA = ((GameObject)a).transform.position - friendlyBase.transform.position;
								Vector3 distanceB = ((GameObject)b).transform.position - friendlyBase.transform.position;
				
								if (distanceA.sqrMagnitude > distanceB.sqrMagnitude) {
										return 1;
								} else if (distanceA.sqrMagnitude < distanceB.sqrMagnitude) {
										return -1;
								}
				
								return 0;
						});




						//checks that the base doesn't have more ships than the current base
						foreach (GameObject checkingEnemyBase in allBases) {

								//Make sure its not our base then get how many ships are nearby
								if (checkingEnemyBase.gameObject.transform.parent.gameObject.tag != friendlyBaseTag) {
										
										BaseController thatBase = checkingEnemyBase.gameObject.transform.parent.gameObject.GetComponent<BaseController> ();
										randomBasesShips = thatBase.nearbyShips;

										//if there is a good chance of winning and not already attacking, send ships to this new base
										if (randomBasesShips < friendlyCount && currentlyAttacking != true) {
			
												weakBaseToAttack = thatBase.transform.position; 
												enemyBase = allBases [currentpos].gameObject.transform.parent.gameObject;
				
												friendlyShips = GameObject.FindGameObjectsWithTag (friendlyTag);
												friendlyCount = friendlyShips.Length;
												startOrbits = new Obittwo[friendlyShips.Length];
				
												Debug.Log ("Computer Moving " + friendlyCount + " " + friendlyTag + " SHIPS!");
				
												for (int i = 0; i < friendlyShips.Length; i++) {
														friendlyShips [i].GetComponent<Obittwo> ().SetBase (enemyBase);
														friendlyShips [i].GetComponent<Unit> ().StartMove (weakBaseToAttack);
												}

				

												while (checkingEnemyBase.gameObject.transform.parent.gameObject.tag != friendlyBaseTag) {

						//	Debug.Log("the enemy base tag is still " + checkingEnemyBase.gameObject.transform.parent.gameObject.tag );
														friendlyShips = GameObject.FindGameObjectsWithTag (friendlyTag);
							
							if (friendlyTag == "Blue") {  blueShipCount = friendlyShips.Length; }
							if (friendlyTag == "Red") { redShipCount = friendlyShips.Length; }
														
							if (friendlyTag == "Green") { greenShipCount = friendlyShips.Length; }


														for (int i = 0; i < friendlyShips.Length; i++) {
																friendlyShips [i].GetComponent<Obittwo> ().SetBase (enemyBase); 
																friendlyShips [i].GetComponent<Unit> ().StartMove (weakBaseToAttack); 
														}

														yield return new WaitForSeconds (1);

												}
					
					
					
										} 

								}
								currentpos++;
						}


						//OLD ATTACKING FOREACH SYSTEM, WORKING WELL AS OF 12/12/14
//							//checks for base with least amount of ships and sets it to newWeakest
//							foreach (GameObject checkingEnemyBase in allBases) {
//
//									if (checkingEnemyBase.gameObject.transform.parent.gameObject.tag != friendlyTag + " Base") {
//
//											BaseController thatBase = checkingEnemyBase.gameObject.transform.parent.gameObject.GetComponent<BaseController> ();
//
//											randomBasesShips = thatBase.nearbyShips;
//
//
//										if (randomBasesShips == 0) {
//											newWeakest = currentpos;
//											}
//
//
//										else if (randomBasesShips < minint) { 
//
//												minint = randomBasesShips; 
//												newWeakest = currentpos;
//										}
//									}
//									currentpos++;
//							}
//
//						//attacks base if newWeakest's has less ships than total number of ships
//						if (minint < friendlyCount) {
//
//								weakBaseToAttack = allBases [newWeakest].transform.position; 
//								enemyBase = allBases [newWeakest].gameObject.transform.parent.gameObject;
//
//								friendlyShips = GameObject.FindGameObjectsWithTag (friendlyTag);
//								startOrbits = new Obittwo[friendlyShips.Length];
//
//								Debug.Log ("Computer Moving " + friendlyCount + " " + friendlyTag + " SHIPS!");
//
//								for (int i = 0; i < friendlyShips.Length; i++) {
//										friendlyShips [i].GetComponent<Obittwo> ().SetBase (enemyBase);
//										friendlyShips [i].GetComponent<Unit> ().StartMove (weakBaseToAttack);
//								}
//						} 
				

						yield return new WaitForSeconds (delay);
				}
		}





	






}



