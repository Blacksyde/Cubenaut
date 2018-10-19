using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

	//may want to move these 3 to a game-manager-type script later
	public int information;
	public int money;
	public int research;
	public int curr_fuel;
	public int scan_range;
	public int curr_battery;


	private int fuel_cap;

	private int battery_cap;
	private int hull_mat;
	private int boost_lvl;

	private int current_sprite;

	public Planet targetPlanet;

	private Planet lastPlanet;

	private Rigidbody2D body;

	public float movementSpeed;

	public Transform fuelRing;
	public Transform scannerRing;
	private DialogManager Dialog;
	//private bool dialogFlag = false;

	private bool menuOpen;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		Dialog = Object.FindObjectOfType<DialogManager> ();
		//hard coding some values in to make sure the rings work
		curr_fuel=50;
		scan_range = 100;
		menuOpen=false;
	}
	
	// Update is called once per frame
	void Update () {
		//hard-coding some keys to change the size of the rings (for testing/slice)
		if(Input.GetKeyDown(KeyCode.O)){
			curr_fuel-=10;
			if(curr_fuel<0)
				curr_fuel=0;
		}
		if(Input.GetKeyDown(KeyCode.P)){
			curr_fuel+=10;
		}
		if(Input.GetKeyDown(KeyCode.K)){
			scan_range-=10;
			if(scan_range<0)
				scan_range=0;
		}
		if(Input.GetKeyDown(KeyCode.L)){
			scan_range+=10;
		}
		fuelRing.localScale = new Vector3 (1+(curr_fuel/10.0f), 1+(curr_fuel/10.0f), 1);
		scannerRing.localScale = new Vector3(1+(scan_range/5.0f), 1+(scan_range/5.0f), 1);
	
	}

	void FixedUpdate()
    {	
		if (targetPlanet&&!menuOpen) {
			moveToTargetPlanet();
		}
		else if(lastPlanet&&!menuOpen){
			moveToLastPlanet();
		}
		else
			body.velocity=Vector3.zero;
    }

	public void SetTargetPlanet(Planet p){
		if(p==targetPlanet)
			return;
		else if(p==null){
			targetPlanet=null;
			return;
		}
		else if(menuOpen)
			return;
			
		if(targetPlanet!=null)
			lastPlanet=targetPlanet;
		targetPlanet = p;
		Dialog.TargetPlanet(targetPlanet);
		menuOpen=true;
	}

	void moveToTargetPlanet(){
		if ((transform.position - targetPlanet.transform.position).magnitude < 1) {
			body.velocity = Vector3.zero;
			this.transform.position = targetPlanet.transform.position;
		} else {
			Vector3 direction = (targetPlanet.transform.position - transform.position).normalized;
			body.velocity = Vector3.zero;
			body.AddForce (targetPlanet.transform.position + direction * movementSpeed * Time.deltaTime);
		}
	}

	void moveToLastPlanet(){
		if ((transform.position - lastPlanet.transform.position).magnitude < 1) {
			body.velocity = Vector3.zero;
			this.transform.position = lastPlanet.transform.position;
		} else {
			Vector3 direction = (lastPlanet.transform.position - transform.position).normalized;
			body.velocity = Vector3.zero;
			body.AddForce (lastPlanet.transform.position + direction * movementSpeed * Time.deltaTime);
		}
	}

	public void setMenuOpen(bool b){
		if(b){
			Time.timeScale=0.0f;
		}
		else{
			Time.timeScale=1.0f;
		}
		menuOpen=b;
	}
}