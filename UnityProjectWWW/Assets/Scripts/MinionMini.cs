using UnityEngine;
using System.Collections;

/* Corey Underdown */

public class MinionMini : MonoBehaviour {
	
	[SerializeField] float rayDistance;
	[SerializeField] LayerMask layersToCheck;
	
	void Update () {
		Debug.DrawLine(transform.position, transform.position + transform.forward * rayDistance, Color.red);
		CheckButton();
	}
	
	void CheckButton(){
		RaycastHit hit;
		
		if(Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, layersToCheck))
		{
			if(Input.GetMouseButtonDown(0) && hit.transform.tag == "Button")
			{
				hit.transform.gameObject.GetComponent<Button>().Activate();
			}

		}
	}
}
