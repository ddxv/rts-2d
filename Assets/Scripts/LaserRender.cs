using UnityEngine;
using System.Collections;



public class LaserRender : MonoBehaviour {

	public LineRenderer lineRenderer;

	public Vector2 pointThis;
	public Vector2 pointThat;

	//Scrolling of Laser
	public float xScrollSpeed;
	public float yScrollSpeed;
	
	//Lasers offset
	public float xOffset;
	public float yOffset;

	public float distFrom;

	private Vector2 coords;

	
	//Material
	public Material myMaterial;
	//public Texture myTexture;
	public float xScaleFactor;
	private float adjustedXSize;

	private GameObject passedObjectAttack;




	// Use this for initialization
	void Start () {


		lineRenderer = gameObject.GetComponent<LineRenderer> ();

		lineRenderer.SetWidth (.03f, .03f);



	}
	
	// Update is called once per frame
	void Update () {

		
		xOffset = Time.time * xScrollSpeed;
		yOffset = Time.time * yScrollSpeed;

		lineRenderer.material.mainTextureOffset = new Vector2 (xOffset, yOffset);

		if (gameObject.transform.parent.gameObject.GetComponent<AnyAttack>().attackingBool == true) {
			lineRenderer.enabled = true;
			lineRenderer.SetPosition (1, gameObject.transform.position);

			pointThat = passedObjectAttack.transform.position;
			pointThis = gameObject.transform.position;

			distFrom = Vector2.Distance(pointThis, pointThat);



			if (distFrom > 1.8f) { gameObject.transform.parent.gameObject.GetComponent<AnyAttack>().attackingBool = false; lineRenderer.renderer.enabled = false;  }


			lineRenderer.SetPosition (0, pointThat);

		}

	
	}

	public void FireLaser(GameObject recieveobject) {

		passedObjectAttack = recieveobject;
	

	}

}