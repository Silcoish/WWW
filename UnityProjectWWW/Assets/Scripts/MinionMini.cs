using UnityEngine;
using System.Collections;

/* Corey Underdown */

public class MinionMini : MonoBehaviour {
	
	[SerializeField] float rayDistance;
	[SerializeField] LayerMask layersToCheck;
	public Camera myCamera;

//	public Texture2D hitTexture;
//	public Texture2D missTexture;
//	private bool showButton = false;
//	private Rect position;


	void Start()
	{
		// Removed by Corey Underdown //
		// Sorry, were giving me errors //
//		position = new Rect ((Screen.width  - (hitTexture.width / 1.25f)) / 2, 
//		                     (Screen.height - hitTexture.height / 1.25f ) / 2, 
//		                     hitTexture.width, 
//		                     hitTexture.height);
	}
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
//				showButton = true;
				hit.transform.gameObject.GetComponent<Button>().Activate();
			}
//			else
//				showButton = false;

		}
	}

//	void OnGUI ()
//	{
//		
//		if(showButton)
//			GUI.DrawTexture (new Rect (position), hitTexture);
//		else
//			GUI.DrawTexture (new Rect (position), missTexture);
//
//	}
}
