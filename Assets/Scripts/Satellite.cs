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
	public float movementSpeed= 5f;
	private Vector3 targetPosition =  new Vector3(0, 0, 0);
	// Use this for initialization
	void Start () {
		 UFO = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void FixedUpdate()
    {
		// if (Input.GetMouseButtonUp(0))
		  	// Debug.Log(Input.mousePosition);
			
			// var v = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);			  
			// if(Input.GetMouseButtonUp(0))
			// 	targetPosition = Camera.main.ScreenToWorldPoint(v);
			Vector3 direction = (targetPosition - transform.position).normalized;
			UFO.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);    
           		    		
    }

	public void SetTargetPosition(Vector3 position){
		targetPosition = position;
	}
}
