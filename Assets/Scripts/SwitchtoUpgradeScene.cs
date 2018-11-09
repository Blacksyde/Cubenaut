using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchtoUpgradeScene : MonoBehaviour {
	public GameObject Upgrade; 
	public GameObject Planets; 
	public void SwitchUpgradeScene(){
		Upgrade.SetActive(true);
		Planets.SetActive(false);
	}

	public void SwitchMainScene(){
		Upgrade.SetActive(false);
		Planets.SetActive(true);

	}

}
