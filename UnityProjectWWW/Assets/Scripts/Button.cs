using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	[SerializeField] bool isActivated = false;
	[SerializeField] bool isDoorButton = false;
	[SerializeField] bool isBridgeButton = false;
	[SerializeField] GameObject puzzleElement;
	[SerializeField] AudioClip clickSound;
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
		AudioSource.PlayClipAtPoint(clickSound, transform.position);
		if(isActivated){
			DeActivate();
		}
		else
		{
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
		isActivated = false;

		if(isDoorButton)
		{
			puzzleElement.GetComponent<Door>().Close();
		}
	}
}
