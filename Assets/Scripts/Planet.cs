using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	private Rarity rarity;
	private Biome biome;
	private Hazard hazard;
	private Resource resource;

	private int earth_dist;
	private int galaxy_pos;

	public string name;

	public Satellite UFO;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnMouseOver () {
		if(Input.GetMouseButtonDown(0)){
			Debug.Log(transform.position);
			UFO.SetTargetPosition(transform.position);
			
		}

	}

	
}
