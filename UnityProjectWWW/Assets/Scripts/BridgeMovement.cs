using UnityEngine;
using System.Collections;

public class BridgeMovement : MonoBehaviour {


	public bool goingDown = false;
	public bool goingUp = false;
	public float speed;
	public AudioClip bridgeSound;

	public Transform thisSide;  //Closer side of the bridge
	public Transform otherSide; // other side of the bridge to drag down

	private bool startTheTimer = false;
	public float bridgeReturnTimer;
	public float timeToRetrunTheBridge;

	private bool raiseTheBridge = false;
	
	void Update () 
	{
		bridgeReturnTimer += Time.deltaTime;
		if(goingDown)
		{
			raiseTheBridge = true;
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
			}
		}

		if(startTheTimer)
		{
			//timer to raise the bridge
			if(bridgeReturnTimer >= timeToRetrunTheBridge)
			{
				goingUp = true;
				startTheTimer = false;
				audio.PlayOneShot (bridgeSound);
			}
		}


		if (raiseTheBridge)
		{

			raiseTheBridge = false;

		}

		if (goingUp)
		{
			raiseTheBridge = true;
			//raises the bridge
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
		goingDown = true;
		audio.PlayOneShot (bridgeSound);
	}



}
