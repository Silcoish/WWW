using UnityEngine;
using System.Collections;

public class DoNotDestroy : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}
	

}
