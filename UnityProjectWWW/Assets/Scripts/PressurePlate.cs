using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	[SerializeField] bool isDoorPressurePlate;
	[SerializeField] GameObject linkedObject;

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "HeavyBox"){
			if(isDoorPressurePlate){
				linkedObject.GetComponent<Door>().Open();
			}
		}
	}

	void OnCollisionExit(Collision col){
		if(col.gameObject.tag == "HeavyBox"){
			if(isDoorPressurePlate){
				linkedObject.GetComponent<Door>().Close();
			}
		}
	}
}
