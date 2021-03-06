﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Galaxy : MonoBehaviour {

	public Planet[] planets;
	public GameObject star;
	public int galaxy_theme;
	public int universe_pos;

	private string name;

	// Use this for initialization
	void Start () {
		int counter = 0;
		int radius = 10;
		float x = 0;
		float y = 0;
		InvokeRepeating("Theme", 0f, 0.3f);
		foreach (Planet planet in planets)
		{
			if(counter == 2){
				counter = 0;
				radius += 10;
			}
			int angle = UnityEngine.Random.Range(0, 360);
			Vector2 pos = PolarToCartesian(angle, radius);
			foreach(Planet other in planets){
				if(other!=planet){
					float diffx = other.transform.position.x-pos[0];
					float diffy = other.transform.position.y-pos[1];
					double dist = Math.Sqrt(diffx*diffx+diffy*diffy);
					if(dist<=3){
						angle = UnityEngine.Random.Range(0, 360);
						pos = PolarToCartesian(angle, radius);
					}
				}
			}
			planet.setPosition(pos[0], pos[1]);
			//Debug.Log("X: "+pos[0]);
			//Debug.Log("Y: "+pos[1]);
			//Debug.Log("RADIUS: "+radius);
			//Debug.Log("..............");

			counter++;
		}	
		
	}
	
	private double nextUpdate=1;
     
     // Update is called once per frame
     void Theme(){
     
          // If the next update is reached
        
			  foreach(Planet p in planets){
				  if (galaxy_theme == 1){
					p.Blink();
			  	  }
				  if (galaxy_theme == 2){
					p.Disco();
			  	  }				
				  if (galaxy_theme == 3){
					p.sizing();
			  	  }
				  if (galaxy_theme == 4){
					p.Blink();
			  	  }									  
				}
	     
     }

	public static Vector2 PolarToCartesian(double angle, double radius)
    {
        double angleRad = (Math.PI / 180.0) * (angle - 90);
        float x = (float)(radius * System.Math.Cos(angleRad));
        float y = (float)(radius * System.Math.Sin(angleRad));
        return new Vector2(x,y);
    }
}