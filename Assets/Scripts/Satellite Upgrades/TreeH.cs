using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TreeH : MonoBehaviour {

	// Use this for initialization
	public Button[] PreReqs;
	public GameObject Button;

	void Start () {
		
	}

	void Update () {
		if (CheckUpgradable(PreReqs)){
			Button.SetActive(true);
		}
	}

	public bool CheckUpgradable(Button[] PreReqs){
		foreach (Button PreReq in PreReqs)
		{
			if(PreReq.colors.normalColor!=  Color.green){
				return false;
			}
		}	

			return true;
	}
}
