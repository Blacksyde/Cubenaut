using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body {

	public int Tier;
	public  int health_range;
	public string display_name;
	private int[] health_ranges = {100,125,150,200};
	private string[] display_names={"Body 0","Body 1", "Body 2", "Body 3"};
	// Use this for initialization
	public void Start () {
		Tier = 0;
		health_range = health_ranges[0];
		display_name = display_names[0];
	}

	public void upgrade(int new_tier){
		Tier = new_tier;
		health_range = health_ranges[new_tier];

		display_name = display_names[new_tier];
	}
	
	// Update is called once per frame
	void Update () {	
	}
}
