using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour {

	public Planet[] planets;
	public GameObject star;
	public int universe_pos;

	private string name;

	// Use this for initialization
	void Start () {
		int counter = 0;
		int radius = 10;
		float x = 0;
		float y = 0;
		foreach (Planet planet in planets)
		{
			if(counter == 2){
				counter = 0;
				radius += 5;
			}
			System.Random rnd = new System.Random();
			float new_x = rnd.Next(-radius, radius);
			if(new_x == x)
				x ++;
			else
				x = new_x;
			if(counter == 1)
				y = -1*Mathf.Sqrt(Mathf.Abs((radius*radius)-(x*x)));
			else
				y = Mathf.Sqrt(Mathf.Abs((radius*radius)-(x*x)));
			planet.setPosition(x,y);
			Debug.Log(x);
			Debug.Log(y);
			Debug.Log(radius);
			Debug.Log("..............");

			counter ++;
		}	
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
