using UnityEngine;
using System.Collections;

public class GreenBases : MonoBehaviour {
	
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
		int reds = Score.greenBases;
		_lbl.text = "Green:\n" + reds.ToString ();
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
