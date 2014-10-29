using UnityEngine;
using System.Collections;

public class MoveToMenu : MonoBehaviour {

	public GameObject[] menus;
	public float cameraSpeed;
	public int i;

	// Use this for initialization
	public void SetActiveMenu (int menuIndex) {
		i = menuIndex;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.MoveTowards(this.transform.position,menus[i].transform.position,cameraSpeed);
	}
}
