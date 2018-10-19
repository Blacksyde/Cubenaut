using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
	public Button scanButton;
	public Button travelButton;
	public GameObject Dialog;
	public Text planetName;
	public Text rarity;
	public Text biome;
	public Text hazard;
	public Text resource;

	private Satellite sat;
   
	// Use this for initialization
	void Start () {
		scanButton.onClick.AddListener(OnScanClick);
		travelButton.onClick.AddListener(OnTravelClick);
		sat = Object.FindObjectOfType<Satellite> ();
	}
	

	void OnScanClick(){
		sat.setMenuOpen(false);
	    Dialog.SetActive(false);
		sat.SetTargetPlanet(null); //set target to null so you go back to last planet
    }

	void OnTravelClick(){
		sat.setMenuOpen(false);
		Dialog.SetActive(false);
	}


	public void TargetPlanet(Planet targetPlanet){
		planetName.text = targetPlanet.name;
		// Debug.Log(targetPlanet.rarity);
		rarity.text = string.Format("Rarity {0}",targetPlanet.rarity);
		biome.text = string.Format("biome {0}",targetPlanet.biome);
		hazard.text = string.Format("hazard {0}",targetPlanet.hazard);
		resource.text = string.Format("resource {0}",targetPlanet.resource);
		Dialog.SetActive(true);
		sat.setMenuOpen(true);
	}
}
