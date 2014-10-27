using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	[SerializeField] int id = -1;

	void OnTriggerEnter(Collider col)
	{
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
