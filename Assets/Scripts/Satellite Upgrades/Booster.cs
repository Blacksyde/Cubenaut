using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster   {

	public int Tier;
	public int Ring_size;
	public string display_name;

	private string[] display_names={"Booster 0\n You can travel to limited distance",
									"Booster 1\n Expands travel range to medium distance planets", 
									"Booster 2\n Expands travel range to the farthest planets in any galaxy", 
									"Booster 3\n Allows travel to stars(overcome gravitational field)",
									"Booster 4\n Allows travel to black holes(overcome gravitational field)"};
	private int[] Ring_sizes={100,200,300,500,500};
	// Use this for initialization
	public void Start () {
		Tier = 0;
		Ring_size = Ring_sizes[0];
		display_name = display_names[0];
	}

	public void upgrade(int new_tier){
		Tier = new_tier;
		Ring_size = Ring_sizes[new_tier];
		display_name = display_names[new_tier];
	}
	
	// Update is called once per frame
	void Update () {	
	}
}
