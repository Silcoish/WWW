using UnityEngine;
using System.Collections;

/* Corey Underdown */

public class MinionMini : MonoBehaviour {
	
	[SerializeField] float rayDistance;
	[SerializeField] LayerMask layersToCheck;
	
	void Update () {
		Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.forward * rayDistance, Color.red);
		CheckButton();
	}
	
	void CheckButton(){
		RaycastHit hit;

		if(Physics.Raycast(transform.position, Camera.main.ScreenPointToRay (Input.mousePosition).direction, out hit, rayDistance, layersToCheck))
		{
			if(Input.GetButtonDown("Fire2") && hit.transform.tag == "Button")
			{
				hit.transform.gameObject.GetComponent<Button>().Activate();
			}

		}
	}
}
