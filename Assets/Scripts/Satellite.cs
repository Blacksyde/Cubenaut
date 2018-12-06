using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;

public class Satellite : MonoBehaviour {

	public static System.Timers.Timer takeOffTimer;

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

	public bool landed;

	private int starsVisited;


	//may want to move these 3 to a game-manager-type script later


	private int current_sprite;

	public Planet targetPlanet;

	public Planet lastPlanet;

	private Rigidbody2D body;

	public float movementSpeed;

	public Transform fuelRing;
	public Transform scannerRing;
	private DialogManager Dialog;
	//private bool dialogFlag = false;

	private AudioManager audioManager;

	private bool menuOpen;

	public void Load(){
		SaveGame.Load();
		curr_battery = SaveGame.Instance.curr_battery;
		true_battery =SaveGame.Instance.true_battery ;
		Body = SaveGame.Instance.Body ;
		Scanner = SaveGame.Instance.Scanner ;
		Booster = SaveGame.Instance.Booster ;
		Probe = SaveGame.Instance.Probe ;
		Subzero = SaveGame.Instance.Subzero ;
		Heat = SaveGame.Instance.Heat ;
		research = SaveGame.Instance.research ;
		information = SaveGame.Instance.information ;
		money = SaveGame.Instance.money;
		landed = SaveGame.Instance.landed;
		starsVisited = SaveGame.Instance.starsVisited ;
		current_sprite = SaveGame.Instance.current_sprite ;
		targetPlanet = SaveGame.Instance.targetPlanet ;
		lastPlanet = SaveGame.Instance.lastPlanet ;
		body = SaveGame.Instance.body ;
		movementSpeed = SaveGame.Instance.movementSpeed ;
		fuelRing = SaveGame.Instance.fuelRing ;
		scannerRing = SaveGame.Instance.scannerRing ;
		Dialog = SaveGame.Instance.Dialog  ;
		audioManager = SaveGame.Instance.audioManager ;
		menuOpen = SaveGame.Instance.menuOpen ;
	}

	public void Save(){
		SaveGame.Instance.curr_battery = curr_battery;
		SaveGame.Instance.true_battery = true_battery;
		SaveGame.Instance.Body = Body;
		SaveGame.Instance.Scanner = Scanner;
		SaveGame.Instance.Booster = Booster;
		SaveGame.Instance.Probe = Probe;
		SaveGame.Instance.Subzero = Subzero;
		SaveGame.Instance.Heat = Heat;
		SaveGame.Instance.research = research;
		SaveGame.Instance.information = information;
		SaveGame.Instance.money = money;
		SaveGame.Instance.landed = landed;
		SaveGame.Instance.starsVisited = starsVisited;
		SaveGame.Instance.current_sprite = current_sprite;
		SaveGame.Instance.targetPlanet = targetPlanet;
		SaveGame.Instance.lastPlanet = lastPlanet;
		SaveGame.Instance.body = body;
		SaveGame.Instance.movementSpeed = movementSpeed;
		SaveGame.Instance.fuelRing = fuelRing;
		SaveGame.Instance.scannerRing = scannerRing;
		SaveGame.Instance.Dialog = Dialog;
		SaveGame.Instance.audioManager = audioManager;
		SaveGame.Instance.menuOpen = menuOpen;
	//may want to move these 3 to a game-manager-type script later
		SaveGame.Save();
	}

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		Dialog = UnityEngine.Object.FindObjectOfType<DialogManager> ();
		audioManager=UnityEngine.Object.FindObjectOfType<AudioManager>();
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
		starsVisited=0;
		menuOpen=false;
		setUpTimer();
		if (Global_Static.Continue){
			Load();
		}
	}

	private void setUpTimer(){
		takeOffTimer = new System.Timers.Timer();
    	takeOffTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
    	takeOffTimer.Interval=2000;
		takeOffTimer.Enabled=false;
	}

	private static void OnTimedEvent(object source, ElapsedEventArgs e)
 	{
     	Debug.Log("Takeoff timer ran out!");
		takeOffTimer.Enabled=false;
		takeOffTimer.Dispose();
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
		if (targetPlanet&&!menuOpen&&!takeOffTimer.Enabled) {
			moveToTargetPlanet();
		}
		else if(lastPlanet&&!menuOpen){
			moveToLastPlanet();
		}
		else
			body.velocity=Vector3.zero;
    }

	public void SetTargetPlanet(Planet p){
		if(p==null){
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

	public void collectResource(int amt){
		information+=amt;
		//HOOK FOR INFO COLLECTION SOUND
		audioManager.PlaySound(5);
	}

	void moveToTargetPlanet(){
		float dist = targetPlanetDist();
		//Debug.Log("DIST: "+dist);
		if (dist < 5) {
			if(!landed){
				Debug.Log("LANDED!");
				if(targetPlanet.biome.name=="Inhabited"){
					//HOOK FOR INHABITED PLANET LANDING SOUND - TOO LONG
					//audioManager.PlaySound(0);
				}
				else{
					//HOOK FOR SATELLITE LANDING SOUND - TOO LONG
					//audioManager.PlaySound(7);
				}
			}
			body.velocity = Vector3.zero;
			//this.transform.position = targetPlanet.transform.position;
			Vector3 direction = (targetPlanet.transform.position - transform.position).normalized;
			body.AddForce (targetPlanet.transform.position + direction * movementSpeed * Time.deltaTime * dist/2);
			landed=true;
		} else {
			Vector3 direction = (targetPlanet.transform.position - transform.position).normalized;
			body.velocity = Vector3.zero;
			body.AddForce (targetPlanet.transform.position + direction * movementSpeed * Time.deltaTime);
			landed=false;
		}
	}

	void moveToLastPlanet(){
		float dist = lastPlanetDist();
		//Debug.Log("DIST: "+dist);
		if (dist < 5) {
			if(!landed){
				Debug.Log("LANDED!");
				if(lastPlanet.biome.name=="Inhabited"){
					//HOOK FOR INHABITED PLANET LANDING SOUND - TOO LONG
					//audioManager.PlaySound(0);
				}
				else{
					//HOOK FOR SATELLITE LANDING SOUND - TOO LONG
					//audioManager.PlaySound(7);
				}
			}
			body.velocity = Vector3.zero;
			//this.transform.position = lastPlanet.transform.position;
			Vector3 direction = (lastPlanet.transform.position - transform.position).normalized;
			body.AddForce (lastPlanet.transform.position + direction * movementSpeed * Time.deltaTime * dist/2);
			landed=true;
		} else {
			Vector3 direction = (lastPlanet.transform.position - transform.position).normalized;
			body.velocity = Vector3.zero;
			body.AddForce (lastPlanet.transform.position + direction * movementSpeed * Time.deltaTime);
			landed=false;
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

	public float targetPlanetDist(){
		return (transform.position - targetPlanet.transform.position).magnitude/targetPlanet.transform.localScale.x;
	}

	public float lastPlanetDist(){
		return (transform.position - lastPlanet.transform.position).magnitude/lastPlanet.transform.localScale.x;
	}
}