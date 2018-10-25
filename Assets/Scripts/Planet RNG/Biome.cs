using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome {
	public Hazard hazard;

	public Resource resource;

	public string name;

	public void Init(){
		hazard=Hazard.getHazard(this);
		resource=Resource.getResource(this);
	}
}
