using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	
	public AudioSource encounter;//0

	public AudioSource bgm1;//1

	public AudioSource gameIntro;//2

	public AudioSource hardBackout;//3

	public AudioSource hardSelect;//4

	public AudioSource infoAcquired;//5

	public AudioSource kaching;//6

	public AudioSource satLanding;//7

	public AudioSource betweenOptions;//8

	public AudioSource newGalaxy;//9

	public AudioSource RPMilestone;//10

	public AudioSource scanning;//11

	public AudioSource softBackout;//12

	public AudioSource softSelect;//13

	public AudioSource satTakeoff;//14

	public AudioSource upgradeSound;//15

	// Use this for initialization
	void Start () {
		bgm1.Play();
	}
	
	// Update is called once per frame
	void Update () {
		//read state from satellite and play sounds based on state
	}

	public void PlaySound(int which){
		if(which==0){
			encounter.Play();
		}
		else if(which==1){
			bgm1.Play();
		}
		else if(which==2){
			gameIntro.Play();
		}
		else if(which==3){
			hardBackout.Play();
		}
		else if(which==4){
			hardSelect.Play();
		}
		else if(which==5){
			infoAcquired.Play();
		}
		else if(which==6){
			kaching.Play();
		}
		else if(which==7){
			satLanding.Play();
		}
		else if(which==8){
			betweenOptions.Play();
		}
		else if(which==9){
			newGalaxy.Play();
		}
		else if(which==10){
			RPMilestone.Play();
		}
		else if(which==11){
			scanning.Play();
		}
		else if(which==12){
			softBackout.Play();
		}
		else if(which==13){
			softSelect.Play();
		}
		else if(which==14){
			satTakeoff.Play();
		}
		else if(which==15){
			upgradeSound.Play();
		}
	}
}
