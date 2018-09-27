using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

	//may want to move these 3 to a game-manager-type script later
	private int information;
	private int money;
	private int research;

	private int fuel_cap;
	private int scan_range;
	private int battery_cap;
	private int hull_mat;
	private int boost_lvl;

	private int current_sprite;

	private Rigidbody2D UFO;
	// Use this for initialization
	void Start () {
		 UFO = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void FixedUpdate()
    {
		if (Input.GetMouseButtonUp(0))
		  	Debug.Log(Input.mousePosition);
        	UFO.MovePosition(Input.mousePosition);
    }
}
