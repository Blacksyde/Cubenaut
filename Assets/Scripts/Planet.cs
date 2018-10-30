using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Planet : MonoBehaviour {

	public Biome biome;
	public Rarity rarity;
	public bool visited = false;

	private int earth_dist;
	private int galaxy_pos;

	private Rotate rot;

	public string name;

	private Satellite sat;
	

	// Use this for initialization
	void Start () {
		sat = Object.FindObjectOfType<Satellite> ();
		
		//randomize size of the planet
		float scale = Random.Range (1.2f, 1.8f);
		this.transform.localScale = new Vector3 (scale, scale, 1);
		//randomize rotation speed/direction
		int rotate = Random.Range (-100, 100);
		rot = GetComponent<Rotate> ();
		rot.rotation_speed = rotate;

		//creating the rarity of the planet, and biome based on it. Also generates hazards and resources as part of the biome

		rarity = new Rarity();
		rarity.Init();
		biome=rarity.getBiome();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown(){
		//Debug.Log("moused over and clicked "+transform.position);
		sat.SetTargetPlanet(this);
	}

	private void visitPlanet(){
		visited = true;
	}
}
