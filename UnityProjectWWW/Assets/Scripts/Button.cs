using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	[SerializeField] bool isActivated = false;
	[SerializeField] bool isDoorButton = false;
	[SerializeField] bool isBridgeButton = false;
	[SerializeField] GameObject puzzleElement;
	// index 0 = on noise
	// index 1 = off noise
	[SerializeField] AudioClip[] clickSound = new AudioClip[2];

	public GameObject buttonOn;
	public GameObject buttonOff;

	public AudioClip doorOpen;
	public AudioClip doorClosed;

	private float bridgeTimer;
	public float timeToRaiseBridge;


	void Update()
	{

		if(isActivated && isBridgeButton)
		{
			bridgeTimer += Time.deltaTime;
			if(bridgeTimer >= timeToRaiseBridge)
				DeActivate();

		}

	}

	public void Activate()
	{
//		Debug.Log ("hit");
		if(isActivated){
			DeActivate();
		}
		else
		{
			AudioSource.PlayClipAtPoint(clickSound[0], transform.position);
			buttonOn.animation.Play ("buttonOn");
			bridgeTimer = 0;
			isActivated = true;

			if(isBridgeButton)
			{
				puzzleElement.SendMessage("LowerBridge", SendMessageOptions.DontRequireReceiver);
			}
			if(isDoorButton)
			{
				puzzleElement.GetComponent<Door>().Open();
				audio.PlayOneShot (doorOpen);
			}
		}

	}

	public void DeActivate()
	{
		AudioSource.PlayClipAtPoint(clickSound[1], transform.position);
		buttonOff.animation.Play ("buttonOff");
		isActivated = false;

		if(isDoorButton)
		{
			puzzleElement.GetComponent<Door>().Close();
			audio.PlayOneShot (doorClosed);
		}
	}
}
