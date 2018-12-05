using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Planet : MonoBehaviour {

	public Biome biome;
	public Rarity rarity;

	private int earth_dist;
	private int galaxy_pos;

	private Rotate rot;

	public string name;

	private Satellite sat;

	public bool scanned = false;

	public bool collected = false;
	private SpriteRenderer m_SpriteRenderer;


	public void setPosition (float x, float y) {
		this.transform.position = new Vector3(x, y, 0.0f);
	}

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

		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		// m_SpriteRenderer.color = Color.black;	

	}
	

     
    

	public void Blink(){
		if(m_SpriteRenderer.color == Color.black){
			m_SpriteRenderer.color = Color.white;
		}
		else if(m_SpriteRenderer.color == Color.white){
			m_SpriteRenderer.color = Color.black;
		}
	}

	public void Disco(){
		m_SpriteRenderer.color = new Color(Random.Range(0F,1F), Random.Range(0, 1F), Random.Range(0, 1F));
	}

	public void sizing(){
		float scale = Random.Range (1.2f, 1.8f);
		this.transform.localScale = new Vector3 (scale, scale, 1);
	}

	private void OnMouseDown(){
		//Debug.Log("moused over and clicked "+transform.position);
		sat.SetTargetPlanet(this);
	}

	public void scanPlanet(){
		//collect resources from the planet upon scan if you're on the planet and it hasn't been collected from yet
		if(sat.landed&&!collected){
			if((sat.targetPlanet==this&&sat.targetPlanetDist()<5)||(sat.lastPlanet==this&&sat.lastPlanetDist()<5)){
				collected=true;
				sat.collectResource(this.biome.resource.val);
				Debug.Log("Got "+this.biome.resource.val+" resources from: " +name);
			}
		}
		scanned = true;
		Debug.Log("scanned planet: " + name);
		m_SpriteRenderer.color = Color.white;
	}
}
