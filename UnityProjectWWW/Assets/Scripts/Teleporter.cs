using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	[SerializeField] GameObject targetPosition;

	void OnCollisionEnter(Collision col)
	{
		col.transform.position = targetPosition.transform.position;
	}
}
