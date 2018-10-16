using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour {
	public Text curr_fuel;
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
		curr_fuel.text = string.Format("Fuel: {0}",sat.curr_fuel);
		scan_range.text = string.Format("Scan Range: {0}",sat.scan_range);
		curr_battery.text = string.Format("Battery: {0}",sat.curr_battery);
		research.text = string.Format("{0}",sat.research);
		information.text = string.Format("{0}",sat.information);
		money.text = string.Format("{0}",sat.money);
	}
}
