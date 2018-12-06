using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

	public void loadByIndex(int SceneIdx){
		if(SceneIdx == 2){
			Global_Static.Continue = true;
			SceneManager.LoadScene(1);
		}
		else{
			Global_Static.Continue = false;
			SceneManager.LoadScene(SceneIdx);
		}
	}
}
