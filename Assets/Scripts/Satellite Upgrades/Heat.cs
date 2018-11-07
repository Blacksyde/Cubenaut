﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heat   {

	public int Tier;
	public int dmg_percentage; 
	public string display_name;

	private int[] dmg_percentages = {100,75,50,0};
	private string[] display_names={"Heat Resist 0\n Take full damage from heat ",
									"Heat Resist 1\n Take 25% less damage from heat ",
									"Heat Resist 2\n Take 50% less damage from heat",
									"Heat Immunity"};
	// Use this for initialization
	public void Start () {
		Tier = 0;
		dmg_percentage = dmg_percentages[0];
		display_name = display_names[0];
	}

	public void upgrade(int new_tier){
		Tier = new_tier;
		dmg_percentage = dmg_percentages[new_tier];
		display_name = display_names[new_tier];
	}
	
	// Update is called once per frame
	void Update () {	
	}
}
