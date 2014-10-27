using UnityEngine;
using System.Collections;

public class HeavyBox : MonoBehaviour {

	public AudioClip boomMotherFucker;

	void OnCollisionEnter (Collision col)
	{
		if(col.transform.tag == "Ground")
		{

			audio.PlayOneShot (boomMotherFucker);
		}
	}
}
