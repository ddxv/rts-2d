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
	private Unit[] startMoves;
	
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

			Debug.Log(friendlyTag + friendlyTag.Length);

						if (friendlyCount > 5) {

				Debug.Log("WE HAVE MORE THAN FIVE SHIPS!");
								//not sure how to auto specify 'anything but this Bases color' for choosing nearest GameObject to move to
								enemyBase = GameObject.FindGameObjectWithTag ("Green Base");
								target = enemyBase.transform.position;
								Debug.DrawLine (target, myTransform.position, Color.red); 

								friendlyShips = GameObject.FindGameObjectsWithTag(friendlyTag);
															
								//friendlyShips.GetComponent<Unit>().StartMove(target);

								startMoves = new Unit[friendlyShips.Length];
								for(int i = 0; i < friendlyShips.Length; i++){
					Debug.Log("LETS MOVE SHIPS!");
									friendlyShips[i].GetComponent<Unit>().StartMove(target);
								}

								}
								yield return new WaitForSeconds (delay);
						}
				}
	

		}	
