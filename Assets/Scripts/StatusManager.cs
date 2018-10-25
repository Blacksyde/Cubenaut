using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour {
	public Text Booster_range;
	public Text scan_range;
	public Text curr_battery;
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
		Booster_range.text = string.Format("Fuel: {0}",sat.getBoosterSize());
		scan_range.text = string.Format("Scan Range: {0}",sat.getScannerRange());
		research.text = string.Format("{0}",sat.research);
		information.text = string.Format("{0}",sat.information);
		money.text = string.Format("{0}",sat.money);
	}
}
