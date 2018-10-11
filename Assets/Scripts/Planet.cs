using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Planet : MonoBehaviour {

	public int rarity;
	public int biome;
	public int hazard;
	public int resource;

	private int earth_dist;
	private int galaxy_pos;

	private Rotate rot;

	public string name;

	private Satellite sat;
	

	// Use this for initialization
	void Start () {
		sat = Object.FindObjectOfType<Satellite> ();
		
		//randomize size of the planet
		float scale = Random.Range (0.9f, 1.2f);
		this.transform.localScale = new Vector3 (scale, scale, 1);
		//randomize rotation speed/direction
		int rotate = Random.Range (-100, 100);
		rot = GetComponent<Rotate> ();
		rot.rotation_speed = rotate;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown(){
		//Debug.Log("moused over and clicked "+transform.position);
		sat.SetTargetPlanet(this);
	}
}
