using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
