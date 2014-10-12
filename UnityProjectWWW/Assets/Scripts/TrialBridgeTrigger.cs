using UnityEngine;
using System.Collections;

public class TrialBridgeTrigger : MonoBehaviour {

	public Transform myBridge;



	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.tag == "Player")
		{
			myBridge.SendMessage("LowerBridge", SendMessageOptions.DontRequireReceiver);
		}
	}
}
