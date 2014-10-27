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
	

	private bool isWalter = true;
	//crosshair
	private Rect position;
	private Rect positionW;

	public Texture2D crosshairTexture;



	public Texture walterTex;
	public Texture strongMinionTex;
	public Texture miniMinionTex;

	private float transitionTimer;

	
	void Awake ()
	{


		statusOfPlayer = false;
		ActivateStrongMinion (statusOfPlayer);
		ActivateMiniMinion (statusOfPlayer);
	}
	
	
	void Start () {

		position = new Rect ((Screen.width  - (crosshairTexture.width / 1.25f)) / 2, 
		                     (Screen.height - crosshairTexture.height / 1.25f ) / 2, 
		                     crosshairTexture.width, 
		                     crosshairTexture.height);

			}
	
	void Update () 
	{
		transitionTimer += Time.deltaTime;

		
		if (playerWizzardCamera.enabled == true && isWalter)
		{


			if(Input.GetButton("Fire1") && transitionTimer >= 1.0f)
			{
				statusOfPlayer = false;
				ActivateWizzard(statusOfPlayer);
				isWalter = false;
				statusOfPlayer = true;
				ActivateStrongMinion (statusOfPlayer);
				transitionTimer = 0;
			}



			if(Input.GetButton("Fire2") && transitionTimer >= 1.0f)
			{
				// can only change to the minion if he is in sight
				statusOfPlayer = false;
				ActivateWizzard(statusOfPlayer);
				isWalter = false;
				statusOfPlayer = true;
				ActivateMiniMinion (statusOfPlayer);
				transitionTimer = 0;
			}

		}
		
		if(playerStrongCamera.enabled == true)
		{

			if(Input.GetButton("Fire1" ) && transitionTimer >= 1.0f)
			{
				// can only change to the minion if he is in sight
				statusOfPlayer = false;
				ActivateStrongMinion(statusOfPlayer);
				statusOfPlayer = true;
				ActivateWizzard (statusOfPlayer);
				isWalter = true;
				transitionTimer = 0;
			}

		}
		
		if(playerMiniCamera.enabled == true)
		{

			if(Input.GetButton("Fire1")&& transitionTimer >= 1.0f)
			{

				statusOfPlayer = false;
				ActivateMiniMinion(statusOfPlayer);
				statusOfPlayer = true;
				ActivateWizzard (statusOfPlayer);
				isWalter = true;
				transitionTimer = 0;
			}

		}
		
		
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	

	void ActivateWizzard (bool statusOf)
	{
		playerWizzard.GetComponent<FirstPersonCharacter>().enabled = statusOf;
		playerWizzard.GetComponent<SimpleMouseRotator>().enabled = statusOf;
		playerWizzardCamera.GetComponent<SimpleMouseRotator>().enabled = statusOf;
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


	
	void OnGUI()
	{
		if(isWalter)
		{
			positionW = new Rect ((Screen.width  - (crosshairTexture.width / 1.25f)) / 2, 
			                      (Screen.height  - (crosshairTexture.height / 1.25f )) / 2, 
			                      crosshairTexture.width, 
			                      crosshairTexture.height);
			GUI.DrawTexture(positionW, crosshairTexture);
			
		}
		else
			GUI.DrawTexture(position, crosshairTexture);


		if (playerStrongCamera.enabled == true)
		{
//			GUI.Box(new Rect(120,10,100,20), "Strong Minion");
			GUI.DrawTexture (new Rect ((Screen.width/2),10,100,100), strongMinionTex);
			
		}
		
		if (playerMiniCamera.enabled == true)
		{
//			GUI.Box(new Rect(230,50,100,20), "Mini Minion");
			GUI.DrawTexture (new Rect ((Screen.width/2),10,100,100), miniMinionTex);
		}
		

	}
}
