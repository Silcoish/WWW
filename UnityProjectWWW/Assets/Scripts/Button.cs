using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	[SerializeField] bool isActivated = false;
	[SerializeField] bool isDoorButton = false;
	[SerializeField] bool isBridgeButton = false;
	[SerializeField] GameObject puzzleElement;

	public void Activate()
	{
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
