using UnityEngine;
using System.Collections;

public class TouchIndicatorCreator : MonoBehaviour
{
	GameObject currentIndicator;

	public int size = 64;
	public float speed = 0.5f;
	public Color color = Color.white;
	public float startAlpha = 0.5f;

	GameObject indicator;
	
	void Start ()
	{
		indicator = Resources.Load ("TouchIndicator/TouchIndicatorObject", typeof(GameObject)) as GameObject;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			MakeInkBlot (Input.mousePosition);
		}
	}

	void MakeInkBlot (Vector3 position)
	{
		currentIndicator = GameObject.Instantiate (indicator) as GameObject;
			
		currentIndicator.transform.parent = transform;
		currentIndicator.transform.position = new Vector3 (0.5f, 0.5f, 0f);
		
		currentIndicator.GetComponent<TouchIndicator> ().MakeIndicator (size, speed, color, startAlpha, new Vector2 (position.x - (Screen.width / 2), position.y - (Screen.height / 2)));
	}
}