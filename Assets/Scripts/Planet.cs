using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Planet : MonoBehaviour {

	private Rarity rarity;
	private Biome biome;
	private Hazard hazard;
	private Resource resource;

	private int earth_dist;
	private int galaxy_pos;

	public string name;

	public Satellite sat;

	// Use this for initialization
	void Start () {
		sat = Object.FindObjectOfType<Satellite> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnMouseDown(){
		//Debug.Log("moused over and clicked "+transform.position);
		sat.SetTargetPlanet(this);
	}
}
