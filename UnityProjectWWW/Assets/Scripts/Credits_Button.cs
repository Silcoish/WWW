using UnityEngine;
using System.Collections;

public class Credits_Button : MonoBehaviour {

	public GameObject[] menus;
	public float cameraSpeed;
	public int i;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		Camera.main.SendMessage ("SetActiveMenu", 1);
	}
}
