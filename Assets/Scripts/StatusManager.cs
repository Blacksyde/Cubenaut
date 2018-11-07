﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour {
	public Text BoosterInfo;
	public Text ScannerInfo;
	public Text ProbeInfo;
	public Text SubzeroInfo;
	public Text HeatInfo;
	public Text BatteryInfo;
	public ProgressBar Pb;
	public Text research;
	public Text information;
	public Text money;
	private Satellite sat;

	
	// Use this for initialization
	void Start () {
		sat = Object.FindObjectOfType<Satellite> ();
        Pb.BarValue = sat.curr_battery;
	}
	
	// Update is called once per frame
	void Update () {
        Pb.BarValue = sat.curr_battery;
		BoosterInfo.text = string.Format("Booster: {0}",sat.getBoosterInfo());
		ScannerInfo.text = string.Format("Scanner: {0}",sat.getScannerInfo());
		ProbeInfo.text = string.Format("Probe: {0}",sat.getProbeInfo());
		SubzeroInfo.text = string.Format("Subzero Resist: {0}",sat.getSubzeroInfo());
		HeatInfo.text = string.Format("Heat Resist: {0}",sat.getHeatInfo());
		BatteryInfo.text = string.Format("Battery: {0}",sat.getBatteryInfo());
		research.text = string.Format("{0}",sat.research);
		information.text = string.Format("{0}",sat.information);
		money.text = string.Format("{0}",sat.money);
	}
}
