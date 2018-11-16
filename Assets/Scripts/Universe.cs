using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universe : MonoBehaviour {

	public Galaxy[] galaxies;
	public GameObject[] game_galaxies;
	private Galaxy currentGalaxy;
	
	public int getCurrentGalaxyPost(){
		return currentGalaxy.universe_pos;
	}

	private void activateGalaxy(int pos){
		foreach (GameObject galaxy in game_galaxies){
			galaxy.SetActive(false);
		}
		game_galaxies[pos].SetActive(true);
	}

	public void gotoLeftGalaxy(){
		int new_pos;
		if(currentGalaxy.universe_pos % 3 == 0){ //0,3,6
			new_pos = currentGalaxy.universe_pos+2;
		}
		else if (currentGalaxy.universe_pos % 3 == 1){//1,4,7
			new_pos = currentGalaxy.universe_pos-1;
		}
		else{//2,5,8
			new_pos = currentGalaxy.universe_pos-1;
		}

		activateGalaxy(new_pos);
		currentGalaxy =  galaxies[new_pos];

	}

	public void gotoRightGalaxy(){
		int new_pos;
		if(currentGalaxy.universe_pos % 3 == 0){ //0,3,6
			new_pos = currentGalaxy.universe_pos+1;
		}
		else if (currentGalaxy.universe_pos % 3 == 1){//1,4,7
			new_pos = currentGalaxy.universe_pos+1;
		}
		else{//2,5,8
			new_pos = currentGalaxy.universe_pos-2;
		}

		activateGalaxy(new_pos);
		currentGalaxy =  galaxies[new_pos];
		
	}

	public void gotoTopGalaxy(){
		int new_pos;
		if(currentGalaxy.universe_pos <= 2){ //0,1,2
			new_pos = currentGalaxy.universe_pos+6;
		}
		else if (currentGalaxy.universe_pos <= 5 ){//3,4,5
			new_pos = currentGalaxy.universe_pos-3;
		}
		else{//6,7,8
			new_pos = currentGalaxy.universe_pos-3;
		}

		activateGalaxy(new_pos);
		currentGalaxy =  galaxies[new_pos];
		
	}

	public void gotoButtomGalaxy(){
		int new_pos;
		if(currentGalaxy.universe_pos <= 2){ //0,1,2
			new_pos = currentGalaxy.universe_pos+3;
		}
		else if (currentGalaxy.universe_pos <= 5 ){//3,4,5
			new_pos = currentGalaxy.universe_pos+3;
		}
		else{//6,7,8
			new_pos = currentGalaxy.universe_pos-6;
		}

		activateGalaxy(new_pos);
		currentGalaxy =  galaxies[new_pos];
		
	}

	// Use this for initialization
	void Start () {
		currentGalaxy = galaxies[0];		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
