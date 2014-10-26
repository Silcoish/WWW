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

	void Update()
	{
//		if(isActivated)
//		{
////			transform.position = Vector3.Lerp(transform.position, endPos, 0.5f);
//
//		}
//		else
//		{
////			transform.position = Vector3.Lerp(transform.position, startPos, 0.5f);
//
//		}
	}

	public void Activate()
	{
		Debug.Log ("hit");
		if(isActivated){
			DeActivate();
		}
		else
		{
			AudioSource.PlayClipAtPoint(clickSound[0], transform.position);
			buttonOn.animation.Play ("buttonOn");
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
