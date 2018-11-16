using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour {
	
	public CircleCollider2D scannerCollider;
	public CircleCollider2D fuelCollider;

	public bool canScan (Collider2D otherCollider) {
		return scannerCollider.IsTouching(otherCollider);
	}

	public bool canTravel (Collider2D otherCollider) {
		return fuelCollider.IsTouching(otherCollider);
	}
}


// void OnScanClick(){
// 		Planet p = sat.targetPlanet;
// 		if(p != null && sat.canScan(p.GetComponent<CircleCollider2D>())){
// 			sat.setMenuOpen(false);
// 			Dialog.SetActive(false);
// 			if (p != null){
// 				p.scanPlanet();
// 			}
// 		}
// 		sat.SetTargetPlanet(null); //set target to null so you go back to last planet
//     }

// 	void OnTravelClick(){
// 		sat.setMenuOpen(false);
// 		Dialog.SetActive(false);
// 		if(sat.landed){
// 			Debug.Log("TAKING OFF!");
// 			sat.landed=false;
// 		}
// 	}