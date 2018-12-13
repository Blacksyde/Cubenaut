using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicPlayer : MonoBehaviour {

	public AudioManager audioManager;

	// Use this for initialization
	void Start () {
		audioManager=FindObjectOfType<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!audioManager.gameIntro.isPlaying)
			audioManager.PlaySound(2);
	}
}
