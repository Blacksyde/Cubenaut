using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class minimap : MonoBehaviour {
	public int GridPos;
	public Universe currentUniverse;
	// Use this for initialization
	void Start () {
		GetComponent<Image>().color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		if(GridPos == currentUniverse.getCurrentGalaxyPost() )
			GetComponent<Image>().color = Color.red;
		else
			GetComponent<Image>().color = Color.white;

	}
}
