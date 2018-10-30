using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchtoUpgradeScene : MonoBehaviour {
	public GameObject Upgrade; 
	public void SwitchUpgradeScene(){
		Upgrade.SetActive(true);
	}

	public void SwitchMainScene(){
		Upgrade.SetActive(false);
	}

}
