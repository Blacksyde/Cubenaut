using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probe   {

	public int Tier;
	public int gain_percentage; 
	public string display_name;

	private int[] gain_percentages = {0, 15, 25, 50, 75,150};
	private string[] display_names={"Probe 0","Probe 1", "Probe 2", "Probe 3","Probe 4","Probe Extra"};
	// Use this for initialization
	public void Start () {
		Tier = 0;
		gain_percentage = gain_percentages[0];
		display_name = display_names[0];
	}

	public void upgrade(int new_tier){
		Tier = new_tier;
		gain_percentage = gain_percentages[new_tier];
		display_name = display_names[new_tier];
	}
	
	// Update is called once per frame
	void Update () {	
	}

}
