using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	[SerializeField] bool opened = false;

	public void Open(){
		opened = true;
		transform.position = transform.position - transform.forward * 5;
	}

	public void Close(){
		opened = false;
		transform.position = transform.position + transform.forward * 5;
	}
}
