using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatUpgradeManager : MonoBehaviour {

	private Satellite sat; 
	
	void Start () {
		sat = Object.FindObjectOfType<Satellite> ();
	}

	public void upgradeProbe(){
		sat.upgradeProbe();
	}
	// public void upgradeScanner(){
	// 	sat.upgradeScanner();
	// }
	public void upgradeBooster(){
		sat.upgradeBooster();
	}
	// public void upgradeSubzero(){
	// 	sat.upgradeSubzero();
	// }
	// public void upgradeHeat(){
	// 	sat.upgradeHeat();
	// }
}
