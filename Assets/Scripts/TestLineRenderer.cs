using UnityEngine;
using System.Collections;

public class TestLineRenderer : MonoBehaviour {


		//Line Renderer
		public LineRenderer myLineRenderer;
		public Transform myPoint1;
		public Transform myPoint2;

	//Scrolling of Laser
	public float xScrollSpeed;
	public float yScrollSpeed;

	//Lasers offset
	public float xOffset;
	public float yOffset;
		
		//Material
		public Material myMaterial;
		public float xScaleFactor;
		private float adjustedXSize;

	//public Texture myTexture;

	void Start() {

		myLineRenderer = gameObject.GetComponent<LineRenderer>();
		myLineRenderer.SetWidth (.03f, .03f);


		}
		
		// Update is called once per frame
		void Update () {

		xOffset = Time.time + xScrollSpeed;
		yOffset = Time.time + yScrollSpeed;

		myLineRenderer.material.mainTextureOffset = new Vector2 (xOffset, yOffset);

		myLineRenderer.SetPosition(0,myPoint1.position);
		myLineRenderer.SetPosition(1,myPoint2.position);
			
			
		}
	}