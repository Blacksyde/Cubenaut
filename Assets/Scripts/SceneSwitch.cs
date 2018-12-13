using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
	private AudioManager audioManager;

	void Start(){
		audioManager=FindObjectOfType<AudioManager>();
	}

	public void loadByIndex(int SceneIdx){
		if(SceneIdx == 2){
			Global_Static.Continue = true;
			SceneManager.LoadScene(1);
			audioManager.PlaySound(4);
		}
		else{
			Global_Static.Continue = false;
			SceneManager.LoadScene(SceneIdx);
			audioManager.PlaySound(4);
		}
	}
}
