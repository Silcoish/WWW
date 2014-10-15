using UnityEngine;
using System.Collections;

/* Corey Underdown */

public class Minion : MonoBehaviour {
	// kypemmanuel@bigpond.com
	// 0419586718

	[SerializeField] float pickUpDistance;
	[SerializeField] LayerMask layersToCheck;
	GameObject currentBox;


	void Start () {

	}

	void Update () {
//		Debug.DrawLine(transform.position, transform.position + transform.forward * pickUpDistance, Color.red);
//		Debug.DrawLine(transform.position, Camera.main.ScreenPointToRay (Input.mousePosition).direction*100, Color.red);


		if(currentBox != null){
			UpdateBox();
		}else{
			CheckBox();
		}
	}

	void CheckBox(){
		RaycastHit hit;




		if(Physics.Raycast(transform.position, Camera.main.ScreenPointToRay (Input.mousePosition).direction , out hit, pickUpDistance, layersToCheck)){
			if(Input.GetButtonDown("Fire1") && (hit.transform.tag == "HeavyBox" || hit.transform.tag == "BouncyBox" || hit.transform.tag == "NormalBox") && currentBox == null)
				PickUp(hit.transform.gameObject);
		}
	}

	void UpdateBox(){
		currentBox.transform.position = transform.position + transform.forward * 2;
		if(Input.GetButtonDown("Fire1")){
			DropBox();
		}
	}

	void DropBox(){
		currentBox.transform.parent = null;
		currentBox.rigidbody.useGravity = true;
		currentBox = null;
	}

	void PickUp(GameObject go){
		currentBox = go;
		currentBox.transform.parent = gameObject.transform;
		currentBox.transform.position = transform.position + transform.forward * 2;
		currentBox.GetComponent<Rigidbody>().useGravity = false;
	}
}
