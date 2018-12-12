using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
	

public class wincheck : MonoBehaviour {
	public GameObject Upgrade; 
	public GameObject Planets;
	public Satellite sat;
	private int wincondition;
	public Text winmessage;

	// Use this for initialization
	void Start () {
		wincondition = 18;
		winmessage.text = "Yes! You explored 25% of the universes! That's a huge Win!!!!";
	}
	
	// Update is called once per frame
	void Update () {
		if(sat.exploration >= wincondition){
			float a = sat.exploration*100/72;
			Upgrade.SetActive(true);
			Planets.SetActive(false);
			wincondition = wincondition + 18;
			winmessage.text = "Yes! You explored " + a + "% of the universes! That's a huge Win!!!!";
		}
	}


}
