using UnityEngine;
using System.Collections;

public class ControllerSupport : MonoBehaviour {
	
	void Update () {
		if(Input.GetAxis("Horizontal") == -1)
		{
			Camera.main.GetComponent<MoveToMenu>().SetActiveMenu(1);
		}

		if(Input.GetAxis("Horizontal") == 1)
		{
			Camera.main.GetComponent<MoveToMenu>().SetActiveMenu(0);
		}
		if(Input.GetKeyDown(KeyCode.JoystickButton0) == true)
		{
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		if(Input.GetKeyDown(KeyCode.JoystickButton1) == true)
		{
			Application.Quit();
		}
	}
}
