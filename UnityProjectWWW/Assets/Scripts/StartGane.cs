using UnityEngine;
using System.Collections;

public class StartGane : MonoBehaviour {
	
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			Application.LoadLevel(1);
		}
	}
}
