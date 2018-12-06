using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedManager : MonoBehaviour {


	public Slider mainSlider;

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
		Time.timeScale = 1.0f;
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
		Time.timeScale = mainSlider.value;
    }


}
