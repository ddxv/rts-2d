using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {
	
	public static bool paused = false;
	public Transform menu;
	public Transform resume;
	
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)){
			paused = togglePause();
			OnPaused();
		}
	}
	
	public void OnPaused()
	{
		if(paused)
		{
			//Instantiate(menu);
			//Instantiate(resume);
		}
		
	}
	
	
	public bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			//Destroy(GameObject.FindWithTag ("resume"));
			//Destroy(GameObject.FindWithTag ("menu"));
			
			
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);   
		}
	}
}