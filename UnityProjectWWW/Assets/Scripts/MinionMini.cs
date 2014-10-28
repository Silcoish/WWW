using UnityEngine;
using System.Collections;

/* Corey Underdown */

public class MinionMini : MonoBehaviour {
	
	[SerializeField] float rayDistance;
	[SerializeField] LayerMask layersToCheck;
	public Camera myCamera;


	void Update () {
		Debug.DrawLine(myCamera.transform.position, myCamera.transform.forward * rayDistance, Color.red);
		CheckButton();
	}
	
	void CheckButton(){
		RaycastHit hit;

		if(Physics.Raycast(myCamera.transform.position, myCamera.ScreenPointToRay (Input.mousePosition).direction, out hit, rayDistance, layersToCheck))
		{

			if(Input.GetButtonDown("Fire2") && hit.transform.tag == "Button")
			{
				hit.transform.gameObject.GetComponent<Button>().Activate();
			}

		}
	}
}
