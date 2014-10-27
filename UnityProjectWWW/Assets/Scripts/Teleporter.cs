using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	[SerializeField] GameObject targetPosition;
	public AudioClip teleportSound;

	void OnCollisionEnter(Collision col)
	{
		col.transform.position = targetPosition.transform.position;
		audio.PlayOneShot (teleportSound);
	}
}
