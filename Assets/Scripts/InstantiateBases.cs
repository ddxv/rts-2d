using UnityEngine;
using System.Collections;

public class InstantiateBases : MonoBehaviour {

	public GameObject basePrefab;
	private Vector2 position;
	private int stuffnearby = 1;
	//private Collider2D[] neighbors;

	void Awake() {

		//Green Base
		for (int g = 0; g < 1; g++) {

			Vector2 newpos = new Vector2(Random.Range(-5.0F, 5.0F), Random.Range(-5.0F, 5.0F ));
			Instantiate(basePrefab, position, Quaternion.identity);
			basePrefab.tag = "Green Base";
			}


		//Blue Base
		for (int y = 0; y < 1; y++) {


			Vector2 newpos = new Vector2(Random.Range(-5.0F, 5.0F), Random.Range(-5.0F, 5.0F ));
			Collider2D [] neighbors = Physics2D.OverlapCircleAll (newpos, 2);
			
			if (neighbors.Length == 0) { 
				position = newpos;
				Instantiate(basePrefab, position, Quaternion.identity);
				basePrefab.tag = "Blue Base";
				} 
			else  {
				y--;  }
		}


		//Red Base
		for (int r = 0; r < 1; r++) {
		
			Vector2 newpos = new Vector2(Random.Range(-5.0F, 5.0F), Random.Range(-5.0F, 5.0F ));
			 Collider2D []  neighbors = Physics2D.OverlapCircleAll (newpos, 2);
			
			if (neighbors.Length == 0) { 
				position = newpos;
				Instantiate(basePrefab, position, Quaternion.identity);
				basePrefab.tag = "Red Base";
			} 
			else   {
				r--; }

		}


		//Enemy Base
		for (int e = 0; e < 4; e++) {
			Vector2 newpos = new Vector2(Random.Range(-5.0F, 5.0F), Random.Range(-5.0F, 5.0F ));
			Collider2D [] neighbors = Physics2D.OverlapCircleAll (newpos, 2);
			
			if (neighbors.Length == 0) { 
				position = newpos;
				Instantiate(basePrefab, position, Quaternion.identity);
				basePrefab.tag = "Enemy Base";
			} 
			else  { 
				e--;} 

	}
}

}









		

	

