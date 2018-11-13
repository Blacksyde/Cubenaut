using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class showarrowbutton : MonoBehaviour {

	public GameObject button;
	// Use this for initialization
	void Start () {
				
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown(){
		Debug.Log("moused over and clicked "+transform.position);
		button.SetActive(true);
	}
}
