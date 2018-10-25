using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public static bool GameIsPaused = false;

	public static void Resume () 
	{
			Time.timeScale = 1f;
			GameIsPaused = false;
		
	}

	public static bool Pause ()
	{
		
		if(GameIsPaused)
		{
			Debug.Log("Game already paused");
			return false;

		}
		else{
			Time.timeScale = 0f;
			GameIsPaused = true;
			return true;
		}
		
	} 
}
