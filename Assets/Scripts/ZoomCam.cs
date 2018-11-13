using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

			if (Input.GetAxis("Mouse ScrollWheel") > 0f)
			{
				// scroll up
				if(GetComponent<Camera> ().orthographicSize <= 30)
					GetComponent<Camera> ().orthographicSize++;
			}
			else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
			{
				// scroll down
				if(GetComponent<Camera> ().orthographicSize >= 5)
					GetComponent<Camera> ().orthographicSize--;


			}
	}
}
