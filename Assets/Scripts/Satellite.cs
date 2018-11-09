using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {


	private int curr_battery;
	private int true_battery;
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
		true_battery = 100;
		menuOpen=false;
	}
	
	// Update is called once per frame
	void Update () {
		//hard-coding some keys to change the size of the rings (for testing/slice)

		curr_battery = true_battery*100/Body.health_range;
		fuelRing.localScale = new Vector3 (1+(Booster.Ring_size/10.0f), 1+(Booster.Ring_size/10.0f), 1);
		scannerRing.localScale = new Vector3(1+(Scanner.Scan_range/5.0f), 1+(Scanner.Scan_range/5.0f), 1);

	}


	//getSize/value
	public int getBoosterSize(){
		return Booster.Ring_size;
	}
	public int getScannerRange(){
		return Scanner.Scan_range;
	}
	public int getBatteryVal(){
		return curr_battery;
	}
	
	//GetINfos
	public string getBatteryInfo(){
		string ret = string.Format("{0}/{1}", true_battery, Body.health_range);
		return ret;
	}
	public string getScannerInfo(){
		return Scanner.display_name;
	}
	public string getBoosterInfo(){
		return Booster.display_name;
	}
	public string getProbeInfo(){
		return Probe.display_name;
	}
	public string getSubzeroInfo(){
		return Subzero.display_name;
	}
	public string getHeatInfo(){
		return Heat.display_name;
	}

	//Upgrades
	public void upgradeProbe(){
		Probe.upgrade(Probe.Tier+1);
	}	
	public void upgradeBooster(){
		Booster.upgrade(Booster.Tier+1);
	}
	public void upgradeScanner(){
		Scanner.upgrade(Scanner.Tier+1);
	}
	public void upgradeBody(){
		Body.upgrade(Body.Tier+1);
	}	
	public void upgradeSubzero(){
		Subzero.upgrade(Subzero.Tier+1);
	}
	public void upgradeHeat(){
		Heat.upgrade(Heat.Tier+1);
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
			menuOpen = TimeManager.Pause();
		}
		else{
			TimeManager.Resume();
			menuOpen = b;
		}
	}
}