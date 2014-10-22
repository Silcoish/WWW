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
	Vector3 startPos, endPos;

	void Start()
	{
		startPos = transform.position;
		endPos = transform.position - transform.right * 0.1f;
	}

	void Update()
	{
		if(isActivated)
		{
			transform.position = Vector3.Lerp(transform.position, endPos, 0.5f);
		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, startPos, 0.5f);
		}
	}

	public void Activate()
	{
		if(isActivated){
			DeActivate();
		}
		else
		{
			AudioSource.PlayClipAtPoint(clickSound[0], transform.position);
			isActivated = true;
			if(isBridgeButton)
			{
				puzzleElement.SendMessage("LowerBridge", SendMessageOptions.DontRequireReceiver);
			}
			if(isDoorButton)
			{
				puzzleElement.GetComponent<Door>().Open();
			}
		}

	}

	public void DeActivate()
	{
		AudioSource.PlayClipAtPoint(clickSound[1], transform.position);
		isActivated = false;

		if(isDoorButton)
		{
			puzzleElement.GetComponent<Door>().Close();
		}
	}
}
