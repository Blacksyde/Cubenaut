using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateDialog : MonoBehaviour {

public GameObject Dialog;

void OnMouseDown () {

	Debug.Log(Dialog.activeSelf);
	Debug.Log(Dialog.activeInHierarchy);
	Dialog.SetActive(true);
	Debug.Log(Dialog.activeSelf);
	Debug.Log(Dialog.activeInHierarchy);

	}
}
