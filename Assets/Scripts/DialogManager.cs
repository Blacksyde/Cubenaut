﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
	public Button collectButton;
	public GameObject Dialog;
	public Text planetName;
	public Text rarity;
	public Text biome;
	public Text hazard;
	public Text resource;
   
	// Use this for initialization
	void Start () {
		Button btn1 = collectButton.GetComponent<Button>();
		btn1.onClick.AddListener(TaskOnClick);
	}
	

	void TaskOnClick()
    {
        //Output this to console when the Button is clicked
	   Dialog.SetActive(!Dialog.activeSelf);
       Debug.Log("haha");
    }


	public void TargetPlanet(Planet targetPlanet){
		planetName.text = targetPlanet.name;
		// rarity.txt = string.format("Rarity {0}",targetPlanet.rarity);
		// biome.txt = string.format("biome {0}",targetPlanet.biome);
		// hazard.txt = string.format("hazard {0}",targetPlanet.hazard);
		// resource.txt = string.format("resource {0}",targetPlanet.resource);
		Dialog.SetActive(!Dialog.activeSelf);
		
	}
}