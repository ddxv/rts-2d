using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour {

	public Vector3 target;

	public float delay = 3;

	private int friendlyCount;

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
	private int minint = 5;

	private GameObject[] friendlyShips;

	private Vector3 weakBaseToAttack;

	//from an example, perhaps not necessary for us, but here because I'm having trouble finding what's wrong
	private Unit[] startMoves;
	private Obittwo[] startOrbits;



	private Transform myTransform;
	
	void Awake(){
		myTransform = transform;
	}


	void Start() {

		allBases = GameObject.FindGameObjectsWithTag ("Base");

		if (gameObject.tag == "Green Base") {
			friendlyTag = "Green";
			enemyTags = new string[] {"Red", "Blue"};
			enemyBaseTags = new string[] {"Red Base", "Blue Base", "Enemy Base"};


		}
		if (gameObject.tag == "Red Base") {
			friendlyTag = "Red";
			enemyTags = new string[] {"Green", "Blue"};
			enemyBaseTags = new string[] {"Green Base", "Blue Base", "Enemy Base"};
		
		}

		if (gameObject.tag == "Blue Base") {
			friendlyTag = "Blue";
			enemyTags = new string[] {"Red", "Green"};
			enemyBaseTags = new string[] {"Green Base", "Red Base", "Enemy Base"};

		}

		StartCoroutine (Loop ());

	}





	
	
	IEnumerator Loop() {
		
		while (true) {


						friendlyCount = GameObject.FindGameObjectsWithTag (friendlyTag).Length - 2;
						minint = 5;
						int ipos = 0;
						foreach (GameObject checkingEnemyBase in allBases) {

								if (checkingEnemyBase.gameObject.transform.parent.gameObject.tag != friendlyTag + " Base") {

										BaseController thatBase = checkingEnemyBase.gameObject.transform.parent.gameObject.GetComponent<BaseController> ();

										randomBasesShips = thatBase.nearbyShips;


										if (randomBasesShips < minint) { 

												minint = randomBasesShips; 
												newWeakest = ipos;
										}
								}
								ipos++;
						}

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
