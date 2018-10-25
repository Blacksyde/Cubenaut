using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard {

	//this is either 0, 1, or 2, corresponding to frost, heat, and corrosion respectively
	public int type;

	//this is a 1-100 percentage value that affects how hurt the satellite will get by the hazard
	public int severity;

	//this is a boolean to signify whether or not the hazard actually occurs 
	public bool exists;

	// Use this for initialization
	void Start () {
		type=-1;
		severity=-1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static Hazard getHazard(Biome b){
		Hazard haz=new Hazard();
		haz.type=-1;
		haz.severity=-1;

		//Average severity of hazards is based on tier.
		// tier 0: 0-20, tier 1: 10-40, tier 2: 30-60, tier 3: 40-100

		//0-100 value used to determine hazard type based on biome
		int ty = Random.Range(0,100);

		if(b.name=="Ice"){
			//FROST - 90
			if(0<=ty&&ty<90){
				haz.type=0;
			}
			//CORROSION - 10
			else if(90<=ty&&ty<100){
				haz.type=2;
			}
			//HEAT - 0
			else {
				haz.type=1;
			}
			int sev = Random.Range(0,20);
			haz.severity=sev;

			int ex = Random.Range(0,100);
			if(0<=ex&&ex<20){
				haz.exists=true;
			}
			else{
				haz.exists=false;
			}
		}

		else if(b.name=="Desert"){
			//HEAT - 70
			if(0<=ty&&ty<70){
				haz.type=1;
			}
			//CORROSION - 20
			else if(70<=ty&&ty<90){
				haz.type=2;
			}
			//FROST - 10
			else {
				haz.type=0;
			}
			int sev = Random.Range(0,20);
			haz.severity=sev;

			int ex = Random.Range(0,100);
			if(0<=ex&&ex<20){
				haz.exists=true;
			}
			else{
				haz.exists=false;
			}
		}

		else if(b.name=="Gas"){
			//CORROSION - 70
			if(0<=ty&&ty<70){
				haz.type=2;
			}
			//HEAT - 20
			else if(70<=ty&&ty<90){
				haz.type=1;
			}
			//FROST - 10
			else {
				haz.type=0;
			}
			int sev = Random.Range(0,20);
			haz.severity=sev;

			int ex = Random.Range(0,100);
			if(0<=ex&&ex<20){
				haz.exists=true;
			}
			else{
				haz.exists=false;
			}
		}

		else if(b.name=="Ocean"){
			//FROST - 45
			if(0<=ty&&ty<45){
				haz.type=0;
			}
			//HEAT - 45
			else if(45<=ty&&ty<90){
				haz.type=1;
			}
			//CORROSION - 10
			else{
				haz.type=2;
			}
			int sev = Random.Range(10,40);
			haz.severity=sev;

			int ex = Random.Range(0,100);
			if(0<=ex&&ex<40){
				haz.exists=true;
			}
			else{
				haz.exists=false;
			}
		}

		else if(b.name=="Volcano"){
			//HEAT - 95
			if(0<=ty&&ty<95){
				haz.type=1;
			}
			//CORROSION - 5
			else if(95<=ty&&ty<100){
				haz.type=2;
			}
			//FROST - 0
			else{
				haz.type=0;
			}
			int sev = Random.Range(10,40);
			haz.severity=sev;

			int ex = Random.Range(0,100);
			if(0<=ex&&ex<40){
				haz.exists=true;
			}
			else{
				haz.exists=false;
			}
		}

		else if(b.name=="Forest"){
			//FROST - 33
			if(0<=ty&&ty<34){
				haz.type=0;
			}
			//HEAT - 33
			else if(34<=ty&&ty<67){
				haz.type=1;
			}
			//CORROSION - 33
			else{
				haz.type=2;
			}
			int sev = Random.Range(30,60);
			haz.severity=sev;

			int ex = Random.Range(0,100);
			if(0<=ex&&ex<60){
				haz.exists=true;
			}
			else{
				haz.exists=false;
			}
		}

		else if(b.name=="Gem"){
			//HEAT - 65
			if(0<=ty&&ty<65){
				haz.type=1;
			}
			//CORROSION - 25
			else if(65<=ty&&ty<90){
				haz.type=2;
			}
			//FROST - 10
			else{
				haz.type=0;
			}
			int sev = Random.Range(30,60);
			haz.severity=sev;

			int ex = Random.Range(0,100);
			if(0<=ex&&ex<60){
				haz.exists=true;
			}
			else{
				haz.exists=false;
			}
		}

		else if(b.name=="Inhabited"){
			//FROST - 33
			if(0<=ty&&ty<34){
				haz.type=0;
			}
			//HEAT - 33
			else if(34<=ty&&ty<67){
				haz.type=1;
			}
			//CORROSION - 33
			else{
				haz.type=2;
			}
			int sev = Random.Range(40,100);
			haz.severity=sev;

			int ex = Random.Range(0,100);
			if(0<=ex&&ex<80){
				haz.exists=true;
			}
			else{
				haz.exists=false;
			}
		}

		else if(b.name=="Star"){
			//ALWAYS HEAT BECAUSE IT'S A STAR
			haz.type=1;
			int sev = Random.Range(40,100);
			haz.severity=sev;

			//ALWAYS EXISTS BECAUSE IT'S A STAR
			haz.exists=true;
		}

		//Debug.Log("Hazard stuff: "+haz.type+" "+haz.severity+" "+haz.exists);
		return haz;
	}
}
