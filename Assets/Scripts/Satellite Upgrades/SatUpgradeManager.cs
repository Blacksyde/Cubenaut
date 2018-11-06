using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatUpgradeManager : MonoBehaviour {

	private Satellite sat; 
	public GameObject[] PreReqs;
	public Button button;
	private ColorBlock cb;
	
	void Start () {
		sat = Object.FindObjectOfType<Satellite> ();
		cb = button.colors;
        cb.normalColor = Color.green;
        cb.highlightedColor = Color.green;
	
	}



	public void upgradeProbe(){
		sat.upgradeProbe();
		
		button.colors = cb;
	}

	public void upgradeBooster(){
		sat.upgradeBooster();
		button.colors = cb;

	}

	public void upgradeBody(){
		sat.upgradeBody();
		button.colors = cb;

	}

	public void upgradeScanner(){
		sat.upgradeScanner();
		button.colors = cb;


	}

	public void upgradeSubzero(){
		sat.upgradeSubzero();
		button.colors = cb;


	}
	public void upgradeHeat(){
		sat.upgradeHeat();
		button.colors = cb;


	}
}
