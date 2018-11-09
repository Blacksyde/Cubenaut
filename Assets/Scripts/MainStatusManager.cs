using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStatusManager : MonoBehaviour {
	public Text BatteryInfo;
	public ProgressBar Pb;
	public Text research;
	public Text information;
	public Text money;
	private Satellite sat;

	
	// Use this for initialization
	void Start () {
		sat = Object.FindObjectOfType<Satellite> ();
        Pb.BarValue = sat.getBatteryVal();
	}
	
	// Update is called once per frame
	void Update () {
        Pb.BarValue = sat.getBatteryVal();
		BatteryInfo.text = string.Format("Battery: {0}",sat.getBatteryInfo());
		research.text = string.Format("{0}",sat.research);
		information.text = string.Format("{0}",sat.information);
		money.text = string.Format("{0}",sat.money);
	}
}
