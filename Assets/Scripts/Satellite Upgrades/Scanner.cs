using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner {

	public int Tier;
	public int Scan_range; 
	public string display_name;

	private int[] Scan_ranges = {100,200, 500, 800};
	private string[] display_names={"Scanner 0","Scanner 1", "Scanner 2", "Scanner 3"};
	// Use this for initialization
	public void Start () {
		Tier = 0;
		Scan_range = Scan_ranges[0];
		display_name = display_names[0];
	}

	public void upgrade(int new_tier){
		Tier = new_tier;
		Scan_range = Scan_ranges[new_tier];
		display_name = display_names[new_tier];
	}
	
	// Update is called once per frame
	
}
