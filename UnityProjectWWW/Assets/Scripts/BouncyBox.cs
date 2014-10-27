using UnityEngine;
using System.Collections;

public class BouncyBox : MonoBehaviour {

	public float jumpForce;
	public AudioClip boing;

	void OnCollisionEnter (Collision col)
	{
		if(col.transform.tag == "Player")
		{
			col.rigidbody.AddForce(Vector3.up * jumpForce);
			audio.PlayOneShot (boing);
		}
	}
}
