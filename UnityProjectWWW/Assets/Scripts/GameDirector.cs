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

	 
	void Awake ()
	{
		statusOfPlayer = false;
		ActivateStrongMinion (statusOfPlayer);
		ActivateMiniMinion (statusOfPlayer);
	}

	// Use this for initialization
	void Start () {
//		onStart = true;

	}
	
	// Update is called once per frame
	void Update () 
	{
//		if(onStart)
//		{
//
//			onStart = false;
//		}
		if(Input.GetKey(KeyCode.Keypad1))
		{
			if(playerStrongCamera.enabled == true)
			{
				statusOfPlayer = false;
				ActivateStrongMinion (statusOfPlayer);

			}
			else if (playerMiniCamera.enabled == true)
			{
				statusOfPlayer = false;
				ActivateMiniMinion (statusOfPlayer);

			}
			statusOfPlayer = true;
			ActivateWizzard(statusOfPlayer);

		}
		if(Input.GetKey(KeyCode.Keypad2))
		{
			if(playerWizzardCamera.enabled == true)
			{
				statusOfPlayer = false;
				ActivateWizzard(statusOfPlayer);
				statusOfPlayer = true;
				ActivateStrongMinion (statusOfPlayer);
			}

		}
		if(Input.GetKey(KeyCode.Keypad3))
		{
			if(playerWizzardCamera.enabled == true)
			{
				statusOfPlayer = false;
				ActivateWizzard(statusOfPlayer);
				statusOfPlayer = true;
				ActivateMiniMinion (statusOfPlayer);
			}

		}
	}
	void ActivateWizzard (bool status)
	{
		playerWizzard.GetComponent<ThirdPersonController>().enabled = status;
		playerWizzardCamera.GetComponent<PlayerCamera>().enabled = status;
		playerWizzardCamera.enabled = status;
	}

	void ActivateStrongMinion (bool status)
	{
		playerStrong.GetComponent<FirstPersonCharacter>().enabled = status;
		playerStrong.GetComponent<SimpleMouseRotator>().enabled = status;
		playerStrongCamera.GetComponent<SimpleMouseRotator>().enabled = status;
		playerStrongCamera.enabled = status;
	}

	void ActivateMiniMinion (bool status)
	{
		playerMini.GetComponent<FirstPersonCharacter>().enabled = status;
		playerMini.GetComponent<SimpleMouseRotator>().enabled = status;
		playerMiniCamera.GetComponent<SimpleMouseRotator>().enabled = status;
		playerMiniCamera.enabled = status;
	}
}
