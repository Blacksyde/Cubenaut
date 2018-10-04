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

	public Planet targetPlanet;

	private Rigidbody2D body;

	public float movementSpeed;

	// Use this for initialization
	void Start () {
		 body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void FixedUpdate()
    {
		//if (Input.GetMouseButtonUp(0))
		  	// Debug.Log(Input.mousePosition);
			
			// var v = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);			  
			// if(Input.GetMouseButtonUp(0))
			// 	targetPosition = Camera.main.ScreenToWorldPoint(v);
		if (targetPlanet) {
			if ((transform.position - targetPlanet.transform.position).magnitude < 1) {
				body.velocity = Vector3.zero;
				this.transform.position = targetPlanet.transform.position;
			} else {
				Vector3 direction = (targetPlanet.transform.position - transform.position).normalized;
				body.velocity = Vector3.zero;
				body.AddForce (targetPlanet.transform.position + direction * movementSpeed * Time.deltaTime);
			}
		}
    }

	public void SetTargetPlanet(Planet p){
		targetPlanet = p;
		Debug.Log("Target planet set to "+targetPlanet.name);
	}
}
