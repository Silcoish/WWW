using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	[SerializeField] int id = -1;

	void OnTriggerEnter(Collider col)
	{
		print ("HIT: " + col.gameObject.name);
		if(id == -1)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		else
		{
			Application.LoadLevel (id + 2);
		}
	}
}
