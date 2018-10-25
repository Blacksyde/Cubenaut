using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster   {

	public int Tier;
	public int Ring_size;
	public string display_name;

	private string[] display_names={"Booster 0","Booster 1", "Booster 2", "Booster 3","Booster 4"};
	private int[] Ring_sizes={100,300,500,500,500};
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
