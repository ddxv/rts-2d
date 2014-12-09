using UnityEngine;
using System.Collections;

public class LoadSinglePlayer : MonoBehaviour {

	
	void OnMouseDown()
	{

			EnemyAI.isGreen = true;
			Application.LoadLevel("BattleScene");
	}
}

