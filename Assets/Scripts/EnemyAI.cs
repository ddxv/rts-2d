using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Vector3 target;
	private GameObject[] go;
	public int moveSpeed = 2;
	public int rotationSpeed = 2;
	public int maxdistance = 3;
	public float delay = 3;
	private int friendlyCount;
	private string friendlyTag;
	private GameObject enemyBase;
	private GameObject[] friendlyShips;

	//from an example, perhaps not necessary for us, but here because I'm having trouble finding what's wrong
	private Unit[] startMoves;
	private Obittwo[] startOrbits;


	private Transform myTransform;
	
	void Awake(){
		myTransform = transform;
	}


	void Start() {


		if (gameObject.tag == "Green Base") {
			friendlyTag = "Green";
		}
		if (gameObject.tag == "Red Base") {
			friendlyTag = "Red";
		}

		if (gameObject.tag == "Blue Base") {
			friendlyTag = "Blue";
		}

		StartCoroutine (Loop ());

				
	}
	
	
	IEnumerator Loop() {
		
				while (true) {



					friendlyCount = GameObject.FindGameObjectsWithTag (friendlyTag).Length;

				//	Debug.Log(friendlyTag + friendlyTag.Length);

						if (friendlyCount > 2) {
												//not sure how to auto specify 'anything but this Bases color' for choosing nearest GameObject to move to
												//enemyBase = GameObject.FindGameObjectWithTag ("Green Base");

												enemyBase = GameObject.FindGameObjectWithTag ("Green Base");
												//target = enemyBase.transform.position;
				
												friendlyShips = GameObject.FindGameObjectsWithTag(friendlyTag);
												startOrbits = new Obittwo[friendlyShips.Length];
												
										for(int i = 0; i < friendlyShips.Length; i++){
													Debug.Log("LETS MOVE " + friendlyCount + " " + friendlyTag + " SHIPS!" );
													friendlyShips[i].GetComponent<Obittwo>().SetBase(enemyBase.gameObject);
													//friendlyShips[i].GetComponent<Unit>().StartMove(target);
													}

											//orbit.SetBase (enemyBase.gameObject);
												} 

				//THIS SCRIPT IS WORKING BELOW. SENDS SHIPS TO CENTER OF ENEMY BASE AND DOES NOT ORBIT.
//								//not sure how to auto specify 'anything but this Bases color' for choosing nearest GameObject to move to
//								enemyBase = GameObject.FindGameObjectWithTag ("Green Base");
//								target = enemyBase.transform.position;
//
//								friendlyShips = GameObject.FindGameObjectsWithTag(friendlyTag);
//								startMoves = new Unit[friendlyShips.Length];
//								
//						for(int i = 0; i < friendlyShips.Length; i++){
//									Debug.Log("LETS MOVE SHIPS!");
//									friendlyShips[i].GetComponent<Unit>().targetLocation = target;
//									friendlyShips[i].GetComponent<Unit>().StartMove(target);
//								}

								
								yield return new WaitForSeconds (delay);
						}
				}


}

		
