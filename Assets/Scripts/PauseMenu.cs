using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static bool MenuActive = false;
	
	public GameObject pauseMenuUI;
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if (MenuActive)
			{
				Resume();
			} else
			{
				Pause();
			}
		}		
	}

	public void Resume ()
	{
		pauseMenuUI.SetActive(false);
		TimeManager.Resume();
		MenuActive = false;
	}

	void Pause ()
	{
		pauseMenuUI.SetActive(true);
		TimeManager.Pause();
		MenuActive = true;
	}

	public void Options()
	{
		Debug.Log("Loading Options....");
	}

	public void Exit()
	{
		Debug.Log("Exiting Game....");
		Application.Quit();
		
		
	}
}
