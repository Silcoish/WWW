using UnityEngine;
using System.Collections;

public class TrialBridgeTrigger : MonoBehaviour {

	public Transform myBridge;
//	public bool tilt;

//	void Awake()
//	{
//		tilt = GetComponentInChildren<BridgeMovement>().goingDown;
//	}

	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.tag == "Player")
		{
			Debug.Log ("Hit the trigger");
			myBridge.SendMessage("LowerBridge", SendMessageOptions.DontRequireReceiver);
		}
	}
}
