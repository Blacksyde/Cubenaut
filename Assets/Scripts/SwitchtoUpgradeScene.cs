using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchtoUpgradeScene : MonoBehaviour {

	public void SwitchUpgradeScene(){
		SceneManager.LoadScene(1);
	}

	public void SwitchMainScene(){
		SceneManager.LoadScene(0);
	}

}
