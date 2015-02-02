using UnityEngine;
using System.Collections;

public class PressIndicator : MonoBehaviour {

	public float delay;
	private bool baseAnimating = false;


	public IEnumerator BaseSelect () {

		if (baseAnimating == false) {
		baseAnimating = true;

		//while (baseAnimating) {

				//		Debug.Log ("Message REcieved");

						for (int i= 0; i < 10; i++) {
								transform.localScale += new Vector3 (.01f, .01f, 0);
//								Debug.Log ("This is happening fast");
								yield return new WaitForSeconds (delay);
						}

						for (int i= 0; i < 10; i++) {
								transform.localScale += new Vector3 (-.01f, -.01f, 0);
								yield return new WaitForSeconds (delay);
						}
			baseAnimating = false;
			//	}

		}

	}
}
