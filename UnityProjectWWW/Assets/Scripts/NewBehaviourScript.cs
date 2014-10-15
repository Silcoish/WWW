using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player")
		{
			Application.LoadLevel(2);
		}
	}
}
