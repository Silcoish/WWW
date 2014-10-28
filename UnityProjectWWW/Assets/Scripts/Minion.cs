using UnityEngine;
using System.Collections;

/* Corey Underdown */

public class Minion : MonoBehaviour {

	[SerializeField] float pickUpDistance;
	[SerializeField] LayerMask layersToCheck;
	GameObject currentBox;
	[SerializeField] Camera myCamera;

	private bool showBox = false;

	void Start () {

	}

	void Update () {
		if(currentBox != null){
			UpdateBox();
		}else{
			CheckBox();
		}
	}

	void CheckBox(){
		RaycastHit hit;
		// New Spherecasting code inserted by Richard at 9.50 pm 26/10/14

		//if(Physics.SphereCast(minionCamera.transform.position, sphereRadius, minionCamera.ScreenPointToRay (Input.mousePosition).direction , out hit, pickUpDistance)){
		if(Physics.Raycast(myCamera.transform.position, myCamera.ScreenPointToRay (Input.mousePosition).direction, out hit, pickUpDistance, layersToCheck)){
			if(hit.transform.tag == "HeavyBox")
				showBox = true;
			else
				showBox = false;


			if(Input.GetButtonDown("Fire2") && (hit.transform.tag == "HeavyBox" || hit.transform.tag == "BouncyBox" || hit.transform.tag == "NormalBox") && currentBox == null)
				PickUp(hit.transform.gameObject);
		}

//		Old RayCast code deleted at 3.50p, 20/10/14
//		if(Physics.Raycast(transform.position, Camera.main.ScreenPointToRay (Input.mousePosition).direction , out hit, pickUpDistance, layersToCheck)){
//			if(Input.GetButtonDown("Fire1") && (hit.transform.tag == "HeavyBox" || hit.transform.tag == "BouncyBox" || hit.transform.tag == "NormalBox") && currentBox == null)
//				PickUp(hit.transform.gameObject);
//		}
	}

	void UpdateBox(){
		currentBox.transform.position = transform.position + transform.forward * 2;
		if(Input.GetButtonDown("Fire2")){
			DropBox();
		}
	}

	void DropBox(){
		currentBox.transform.parent = null;
		currentBox.rigidbody.useGravity = true;
		currentBox = null;
	}

	void PickUp(GameObject go){
		print ("pickup: " + go.transform.name);
		currentBox = go;
		currentBox.transform.parent = gameObject.transform;
		currentBox.transform.position = transform.position + transform.forward * 2;
		currentBox.GetComponent<Rigidbody>().useGravity = false;
	}
	void OnGUI ()
	{

		if(showBox)
			GUI.Box(new Rect(120,10,100,20), "BOX");
	}
}
