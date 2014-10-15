using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour {


	public GameObject playerWizzard;
	public Camera playerWizzardCamera;
	public GameObject playerStrong;
	public Camera playerStrongCamera;
	public GameObject playerMini;
	public Camera playerMiniCamera;

	private bool statusOfPlayer;

	private bool onStart;

//	public float squareRange;
//	public float angle;
//
//	public bool canChangeStrong;
//	public bool canChangeMini;
//	public bool canChangeWizzard;

	 
	void Awake ()
	{
		statusOfPlayer = false;
		ActivateStrongMinion (statusOfPlayer);
		ActivateMiniMinion (statusOfPlayer);
//		canChangeWizzard = true;
//		canChangeStrong = false;
//		canChangeMini = false;
	}

	// Use this for initialization
	void Start () {
//		onStart = true;

		/*    if((_transform.position - _player.position).sqrMagnitude < squareRange &&
    (Vector3.Angle(player.transform.position - _transform.position, transform.forward) <= angle)){}*/

	}
	
	// Update is called once per frame
	void Update () 
	{
//		if(onStart)
//		{
//
//			onStart = false;
//		}
//		if (playerWizzardCamera.enabled == true)
//		{
//			if ((playerWizzard.transform.position - playerStrong.transform.position).sqrMagnitude < squareRange &&
//				(Vector3.Angle (playerStrong.transform.position - playerWizzard.transform.position, transform.forward) <= angle)) 
//			{
//				canChangeStrong = true;
//			}
//			else
//			{
//				canChangeStrong = false;
//			}
//			if ((playerWizzard.transform.position - playerMini.transform.position).sqrMagnitude < squareRange &&
//			    (Vector3.Angle (playerMini.transform.position - playerWizzard.transform.position, transform.forward) <= angle)) 
//			{
//				canChangeMini = true;
//			}
//			else
//			{
//				canChangeMini = false;
//			}
//		}

//		if(playerStrongCamera.enabled == true)
//		{
//			if ((playerStrong.transform.position - playerWizzard.transform.position).sqrMagnitude < squareRange &&
//			    (Vector3.Angle (playerWizzard.transform.position - playerStrong.transform.position, transform.forward) <= angle)) 
//			{
//				canChangeWizzard = true;
//			}
//			else
//			{
//				canChangeWizzard = false;
//			}
//		}
//
//		if(playerMiniCamera.enabled == true)
//		{
//			if ((playerMini.transform.position - playerWizzard.transform.position).sqrMagnitude < squareRange &&
//			    (Vector3.Angle (playerWizzard.transform.position - playerMini.transform.position, transform.forward) <= angle)) 
//			{
//				canChangeWizzard = true;
//			}
//			else
//			{
//				canChangeWizzard = false;
//			}
//		}
		if(Input.GetButtonDown("PlayerButton"))
		{

			if(playerStrongCamera.enabled == true)// && canChangeWizzard)
			{
				statusOfPlayer = false;
				ActivateStrongMinion (statusOfPlayer);

			}
			else if (playerMiniCamera.enabled == true)// && canChangeWizzard)
			{
				statusOfPlayer = false;
				ActivateMiniMinion (statusOfPlayer);

			}
			statusOfPlayer = true;
			ActivateWizzard(statusOfPlayer);

		}
		if(Input.GetButtonDown("StrongMinion"))
		{
			if(playerWizzardCamera.enabled == true)// && canChangeStrong)
			{
				statusOfPlayer = false;
				ActivateWizzard(statusOfPlayer);
				statusOfPlayer = true;
				ActivateStrongMinion (statusOfPlayer);
			}

		}
		if(Input.GetButtonDown("MiniMinion"))
		{
			if(playerWizzardCamera.enabled == true)// && canChangeMini)
			{
				statusOfPlayer = false;
				ActivateWizzard(statusOfPlayer);
				statusOfPlayer = true;
				ActivateMiniMinion (statusOfPlayer);
			}

		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	void ActivateWizzard (bool statusOf)
	{
		playerWizzard.GetComponent<ThirdPersonController>().enabled = statusOf;
		playerWizzardCamera.GetComponent<PlayerCamera>().enabled = statusOf;
		playerWizzardCamera.GetComponent<AudioListener>().enabled = statusOf;
		playerWizzardCamera.enabled = statusOf;
	}

	void ActivateStrongMinion (bool statusOf)
	{
		playerStrong.GetComponent<FirstPersonCharacter>().enabled = statusOf;
		playerStrong.GetComponent<SimpleMouseRotator>().enabled = statusOf;
		playerStrongCamera.GetComponent<SimpleMouseRotator>().enabled = statusOf;
		playerStrongCamera.GetComponent<AudioListener>().enabled = statusOf;
		playerStrongCamera.enabled = statusOf;
	}

	void ActivateMiniMinion (bool statusOf)
	{
		playerMini.GetComponent<FirstPersonCharacter>().enabled = statusOf;
		playerMini.GetComponent<SimpleMouseRotator>().enabled = statusOf;
		playerMiniCamera.GetComponent<SimpleMouseRotator>().enabled = statusOf;
		playerMiniCamera.GetComponent<AudioListener>().enabled = statusOf;
		playerMiniCamera.enabled = statusOf;
	}
}
