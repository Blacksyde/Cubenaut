using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {


	public int curr_battery;
	//upgrades
	private Body Body;
	private Scanner Scanner;
	private Booster Booster;
	private Probe Probe;
	private Subzero Subzero;
	private Heat Heat;
	//economy
	public int research;
	public int information;
	public int money;

	//may want to move these 3 to a game-manager-type script later
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
		Body = new Body();
		Scanner = new Scanner();
		Booster = new Booster();
		Probe = new Probe();
		Subzero = new Subzero();
		Heat = new Heat();
		Body.Start();
		Scanner.Start();
		Booster.Start();
		Probe.Start();
		Subzero.Start();
		Heat.Start();
		//hard coding some values in to make sure the rings work
		curr_battery = 100;
		menuOpen=false;
	}
	
	// Update is called once per frame
	void Update () {
		//hard-coding some keys to change the size of the rings (for testing/slice)

		curr_battery = curr_battery/Body.health_range*100;
		fuelRing.localScale = new Vector3 (1+(Booster.Ring_size/10.0f), 1+(Booster.Ring_size/10.0f), 1);
		scannerRing.localScale = new Vector3(1+(Scanner.Scan_range/5.0f), 1+(Scanner.Scan_range/5.0f), 1);

	}

	public int getBoosterSize(){
		return Booster.Ring_size;
	}

	public int getScannerRange(){
		return Scanner.Scan_range;
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
			TimeManager.Pause();
		}
		else{
			TimeManager.Resume();
		}
		menuOpen=b;
	}
}