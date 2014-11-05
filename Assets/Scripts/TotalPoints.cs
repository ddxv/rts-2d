using UnityEngine;
using System.Collections;

public class TotalPoints : MonoBehaviour {
	
	//change color
	//spawn at specific point
	//pass in a string to be displayed
	
	
	private UILabel _lbl;
	
	public GameObject target;
	public Camera worldCamera;
	public Camera guiCamera;
	
	
	
	
	void Awake () { 
		_lbl = GetComponent<UILabel>();
		//if (_lbl == null)
		//	Debug.LogError ("CouldNOtodododdo");
	}
	
	void Update () {
		int score = Score.totalPoints;
		_lbl.text = "Total Score:\n" + score.ToString ();
	}
	
	
	public Color TextColor {
		get { return _lbl.color; }
		set { _lbl.color = value; }
		
		
	}
	
	public string Text {
		get { return _lbl.text; }
		set { _lbl.text = value; }
	}
	
	
	
	
}
