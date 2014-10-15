using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	[SerializeField] int id;

	void OnTriggerEnter(Collider col)
	{
		Application.LoadLevel (id + 1);
	}
}
