using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour {
	public Hazard hazard;

	public Resource resource;

	public string name;

	// Use this for initialization
	void Start () {
		hazard=Hazard.getHazard(this);
		resource=Resource.getResource(this);
	}
}
