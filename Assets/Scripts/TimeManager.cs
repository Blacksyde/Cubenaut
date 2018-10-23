using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public static bool GameIsPaused = false;
	public static int pauseTracker = 0;

	public static void Resume () 
	{
		pauseTracker--;
		if(pauseTracker == 0){
			Time.timeScale = 1f;
			GameIsPaused = false;
		}
		
		Debug.Log("number of systems pausing: "+ pauseTracker);

	}

	public static void Pause ()
	{
		pauseTracker++;
		Time.timeScale = 0f;
		GameIsPaused = true;

		Debug.Log("number of systems pausing: "+ pauseTracker);
	} 
}
