using UnityEngine;
using System.Collections;

/* Corey Underdown */

public class MinionMini : MonoBehaviour {
	
	[SerializeField] float rayDistance;
	[SerializeField] LayerMask layersToCheck;

	/// Edited by Richard at 3.57pm 20/10/14 to include a shpere cast
	[SerializeField] float sphereRadius;
	/// </summary>
	/// 
	/// 

	//Put in my richard at 9.50 pm 26/10 because the camera.main, might not necessarily be this minion's camera
	public Camera miniMinionCamera;


	void Update () {
		Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.forward * rayDistance, Color.red);
		CheckButton();
	}
	
	void CheckButton(){
		RaycastHit hit;

		//deleted RayCast command the has been superceeded by the spherecast command
		if(Physics.Raycast(transform.position, miniMinionCamera.ScreenPointToRay (Input.mousePosition).direction, out hit, rayDistance, layersToCheck))
		{

		//Edited by richard 4.00pm 20/10/14 to include spherecast
		//if(Physics.SphereCast(Camera.main.transform.position, sphereRadius,/* Camera.main.ScreenPointToRay (Input.mousePosition).direction*/ Camera.main.transform.forward , out hit, rayDistance))
		//{
			// <> //


			if(Input.GetButtonDown("Fire1") && hit.transform.tag == "Button")
			{
				hit.transform.gameObject.GetComponent<Button>().Activate();
			}

		}
	}
}
