using UnityEngine;
using System.Collections;

public class BridgeMovement : MonoBehaviour {


	public bool goingDown = false;
	public bool goingUp = false;
	public float speed;
	public float rotateBridge;

	public Transform thisSide;  //Closer side of the bridge
	public Transform otherSide; // other side of the bridge to drag down

	private bool startTheTimer = false;
	public float bridgeReturnTimer;
	public float timeToRetrunTheBridge;

	// Use this for initialization
	void Start () {
	rotateBridge = 270;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bridgeReturnTimer += Time.deltaTime;
		if(goingDown)
		{
			//lowers the bridge
			if(thisSide.eulerAngles.z >= 268)
			{
				thisSide.Rotate (Vector3.back * -speed * Time.deltaTime);
				otherSide.Rotate (Vector3.back * -speed * Time.deltaTime);
			}

			if(thisSide.eulerAngles.z >= 0 && thisSide.eulerAngles.z <= 269)
			{
				goingDown = false;
				bridgeReturnTimer = 0;
				startTheTimer = true;
				Debug.Log ("start the timer");
			}
		}

		if(startTheTimer)
		{
			if(bridgeReturnTimer >= timeToRetrunTheBridge)
			{
				goingUp = true;
				startTheTimer = false;
				Debug.Log ("stop the timer");

			}
		}

		if (goingUp)
		{
			Debug.Log ("going up");

			if(thisSide.eulerAngles.z >= 270 || thisSide.eulerAngles.z <= 2)
			{
				thisSide.Rotate (Vector3.back * speed * Time.deltaTime);
				otherSide.Rotate (Vector3.back * speed * Time.deltaTime);
			}
			
			if(thisSide.eulerAngles.z >= 2 && thisSide.eulerAngles.z <= 270)
			{
				goingUp = false;
			}

		}


	}

	//Message recieved from the trigger and turning the goingDown bool to true to lower the bridges
	public void LowerBridge()
	{
//		Debug.Log("GoingDown recieved");
		goingDown = true;
	}



}
