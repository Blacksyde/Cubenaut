using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particalManager : MonoBehaviour {

	private ParticleSystem ps;
    public float hSliderValue = 1.0f;
    public bool useUnscaledTime = false;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.useUnscaledTime = useUnscaledTime;

        Time.timeScale = hSliderValue;
    }

    void OnGUI()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(10, 30, 200, 30), hSliderValue, 0.0F, 100.0F);
        // useUnscaledTime = GUI.Toggle(new Rect(25, 75, 100, 30), useUnscaledTime, "Use Unscaled Time");
    }
}
