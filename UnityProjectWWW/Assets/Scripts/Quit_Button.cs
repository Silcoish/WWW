using UnityEngine;
using System.Collections;

public class Quit_Button : MonoBehaviour {

	// Update is called once per frame
	void OnMouseDown() {
		Application.Quit();
	}
}
