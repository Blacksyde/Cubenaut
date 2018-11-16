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

	public Rings Rings;

	private Satellite sat;
   
	// Use this for initialization
	void Start () {
		scanButton.onClick.AddListener(OnScanClick);
		travelButton.onClick.AddListener(OnTravelClick);
		sat = Object.FindObjectOfType<Satellite> ();
	}
	

	void OnScanClick(){
		Planet p = sat.targetPlanet;
		if(p != null && Rings.canScan(p.GetComponent<CircleCollider2D>())){
			sat.setMenuOpen(false);
			Dialog.SetActive(false);
			if (p != null){
				p.scanPlanet();
			}
		}
		sat.SetTargetPlanet(null); //set target to null so you go back to last planet
    }

	void OnTravelClick(){
		sat.setMenuOpen(false);
		Dialog.SetActive(false);
		if(sat.landed){
			Debug.Log("TAKING OFF!");
			sat.landed=false;
		}
	}


	public void TargetPlanet(Planet targetPlanet){
		planetName.text = targetPlanet.name;
		// Debug.Log(targetPlanet.rarity);
		rarity.text = "Rarity: "+targetPlanet.rarity.rarity_val;
		hazard.text = "Hazard: "+targetPlanet.biome.hazard.type+" / Severity: "+targetPlanet.biome.hazard.severity+"% / Exists: "+targetPlanet.biome.hazard.exists;
		biome.text = "Biome Name: "+targetPlanet.biome.name;
		resource.text = "Resource Amount: "+targetPlanet.biome.resource.val;
		Dialog.SetActive(true);
		sat.setMenuOpen(true);
	}
}
