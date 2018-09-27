using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
	public int rotation_speed;
	void Update () 
    {
        //Rotate thet transform of the game object this is attached to by 45 degrees, taking into account the time elapsed since last frame.
        transform.Rotate (new Vector3 (0, 0, rotation_speed) * Time.deltaTime);
    }
}
