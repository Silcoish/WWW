using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WalkingSFX : MonoBehaviour {

	public Camera myCamera;

	private float stepTimer = 0.0f;
	public float timeTillNextStep;

	//Lists of audioclips
	public List<AudioClip> stepSource;

	private bool isGrounded;
	public GameObject target;

	void Start()
	{
		isGrounded = FirstPersonCharacter.inst.grounded;

	}

	void FixedUpdate ()
	{
		stepTimer += Time.deltaTime;


		if((Input.GetAxis("Horizontal")>= 0.5 || Input.GetAxis("Horizontal")<= -0.5 )|| (Input.GetAxis("Vertical") >= 0.5 || Input.GetAxis("Vertical") <= -0.5) && isGrounded)
		{
			//Debug.Log(isGrounded);  Always True :/
			if (myCamera.enabled == true && stepTimer >= timeTillNextStep)
			{
				GetRandomSound (stepSource);
			}

		}
	}


	void GetRandomSound (List<AudioClip> randomClip)
	{
		int j = Random.Range(0, (randomClip.Count - 1));
		audio.PlayOneShot (randomClip[j]);
		stepTimer = 0;
	}

}
