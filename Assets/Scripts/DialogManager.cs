using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Timers;

public class DialogManager : MonoBehaviour {
	public Button scanButton;
	public Button travelButton;
	public GameObject Dialog;
	public Text planetName;
	public Text rarity;
	public Text biome;
	public Text hazard;
	public Text resource;

	private AudioManager audioManager;

	public Rings rings;

	private Satellite sat;
   
	// Use this for initialization
	void Start () {
		scanButton.onClick.AddListener(OnScanClick);
		travelButton.onClick.AddListener(OnTravelClick);
		sat = UnityEngine.Object.FindObjectOfType<Satellite> ();
		audioManager=UnityEngine.Object.FindObjectOfType<AudioManager>();
		rings = UnityEngine.Object.FindObjectOfType<Rings> ();
	}
	

	void OnScanClick(){
		Planet p = sat.targetPlanet;
		//HOOK FOR SCAN SOUND
		audioManager.PlaySound(11);
		if(p != null){
			sat.setMenuOpen(false);
			Dialog.SetActive(false);

			if (rings.canScan(p.GetComponent<CircleCollider2D>())){
				p.scanPlanet();
			}
			
		}
		sat.SetTargetPlanet(null); //set target to null so you go back to last planet
    }

	void OnTravelClick(){
		sat.setMenuOpen(false);
		Dialog.SetActive(false);
		System.Timers.Timer t = Satellite.takeOffTimer;
		t.Enabled=true;
		audioManager.PlaySound(14);
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
