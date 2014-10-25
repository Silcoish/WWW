using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour {
	
	
	public GameObject playerWizzard;
	public Camera playerWizzardCamera;
	public GameObject playerStrong;
	public Camera playerStrongCamera;
	public GameObject playerMini;
	public Camera playerMiniCamera;
//	public Camera currentCamera;
	
	private bool statusOfPlayer;
	
	private bool onStart;
	
	
	public bool canChangeStrong;
	public bool canChangeMini;
	public bool canChangeWizzard;
	
	public float sphereRadius;
	public float rayDistance;

	private bool isWalter = true;
	//crosshair
	private Rect position;
	private Rect positionW;
	public float offsetW;
	public float offsetH;
	public Texture2D crosshairTexture;

	private LayerMask layermask;
	private int glassLayer;

	
	void Awake ()
	{

//		currentCamera = playerWizzardCamera;
		statusOfPlayer = false;
		ActivateStrongMinion (statusOfPlayer);
		ActivateMiniMinion (statusOfPlayer);
		MakeAllFalse();
	}
	
	
	void Start () {
		layermask = LayerMask.NameToLayer ("Button") | LayerMask.NameToLayer ("Glass");
		glassLayer = 1 << 10;
		glassLayer = ~ glassLayer;
		position = new Rect ((Screen.width - (crosshairTexture.width / 1.25f)) / 2, (Screen.height - crosshairTexture.height / 1.25f ) / 2, crosshairTexture.width, crosshairTexture.height);
	}
	
	void Update () 
	{

		RaycastHit hit;
		
		
		if (playerWizzardCamera.enabled == true)
		{

			//sends out a sphere cast and is looking for the mini or heavy minions
			bool didHit = Physics.SphereCast(playerWizzard.transform.position, sphereRadius, playerWizzardCamera.transform.forward  /*playerWizzardCamera.transform.forward*/, out hit, Mathf.Infinity, glassLayer);
			Debug.DrawRay(playerWizzard.transform.position, playerWizzardCamera.ScreenPointToRay (Input.mousePosition).direction, Color.black);

			if ((didHit && hit.transform.tag == "HeavyMinion"))
			{
				//allows GUI to display that you can see the minion
				canChangeStrong = true;
				// can only change to the minion if he is in sight
				if(Input.GetButtonDown("Fire3") && canChangeStrong)
				{
					statusOfPlayer = false;
					ActivateWizzard(statusOfPlayer);
					isWalter = false;
					statusOfPlayer = true;
					ActivateStrongMinion (statusOfPlayer);
					MakeAllFalse();
				}
			}
			else
			{
				canChangeStrong = false;
			}
			if (didHit && hit.transform.tag == "MiniMinion") 
			{
				//allows GUI to display that you can see the minion
				canChangeMini = true;
				if(Input.GetButtonDown("Fire3") && canChangeMini)
				{
					// can only change to the minion if he is in sight
					statusOfPlayer = false;
					ActivateWizzard(statusOfPlayer);
					isWalter = false;
					statusOfPlayer = true;
					ActivateMiniMinion (statusOfPlayer);
					MakeAllFalse();
				}
			}
			else
			{
				canChangeMini = false;
			}
		}
		
		if(playerStrongCamera.enabled == true)
		{
			Ray ray = playerStrongCamera.ScreenPointToRay(Input.mousePosition);
	//		Physics.SphereCast(/*playerStrong.transform.position*/ Camera.main.transform.position, sphereRadius, /*Camera.main.ScreenPointToRay (Input.mousePosition).direction */ Camera.main.transform.forward, out hit, rayDistance, layermask);
			bool didHit = Physics.SphereCast(ray, sphereRadius, out hit, Mathf.Infinity, layermask);
			Debug.DrawRay(playerStrongCamera.transform.position, playerStrongCamera.ScreenPointToRay (Input.mousePosition).direction, Color.black);

//			Debug.Log (hit.transform.tag);
			if (didHit && hit.transform.tag == "Player") 
			{
				//allows GUI to display that you can see the minion
				canChangeWizzard = true;
				
				if(Input.GetButtonDown("Fire3") && canChangeWizzard)
				{
					// can only change to the minion if he is in sight
					statusOfPlayer = false;
					ActivateStrongMinion(statusOfPlayer);
					statusOfPlayer = true;
					ActivateWizzard (statusOfPlayer);
					isWalter = true;
					MakeAllFalse();
				}
			}
			else
			{
				canChangeWizzard = false;
			}
		}
		
		if(playerMiniCamera.enabled == true)
		{
			Ray ray = playerMiniCamera.ScreenPointToRay(Input.mousePosition);
			//		Physics.SphereCast(/*playerStrong.transform.position*/ Camera.main.transform.position, sphereRadius, /*Camera.main.ScreenPointToRay (Input.mousePosition).direction */ Camera.main.transform.forward, out hit, rayDistance, layermask);
			bool didHit = Physics.SphereCast(ray, sphereRadius, out hit, Mathf.Infinity, layermask);
			Debug.DrawRay(playerMiniCamera.transform.position, playerMiniCamera.ScreenPointToRay (Input.mousePosition).direction, Color.black);
			if (didHit && hit.transform.tag == "Player") 
			{
				//allows GUI to display that you can see the minion
				canChangeWizzard = true;
				if(Input.GetButtonDown("Fire3") && canChangeWizzard)
				{
					// can only change to the minion if he is in sight
					statusOfPlayer = false;
					ActivateMiniMinion(statusOfPlayer);
					statusOfPlayer = true;
					ActivateWizzard (statusOfPlayer);
					isWalter = true;
					MakeAllFalse();
				}
			}
			else
			{
				canChangeWizzard = false;
			}
		}
		
		
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	
	void MakeAllFalse ()
	{
		canChangeMini = false;
		canChangeStrong = false;
		canChangeWizzard = false;
	}
	void ActivateWizzard (bool statusOf)
	{
		playerWizzard.GetComponent<ThirdPersonController>().enabled = statusOf;
		playerWizzardCamera.GetComponent<PlayerCamera>().enabled = statusOf;
		playerWizzardCamera.GetComponent<AudioListener>().enabled = statusOf;
		playerWizzardCamera.GetComponent<SmoothLookAtWalter>().enabled = statusOf;
		playerWizzardCamera.GetComponent<MouseOrbitWalter>().enabled = statusOf;
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
			positionW = new Rect (((Screen.width  + offsetW) - (crosshairTexture.width / 1.25f)) / 2, 
			                      ((Screen.height + offsetH) - (crosshairTexture.height / 1.25f )) / 2, 
			                      crosshairTexture.width, 
			                      crosshairTexture.height);
			GUI.DrawTexture(positionW, crosshairTexture);
			
		}
		else
			GUI.DrawTexture(position, crosshairTexture);


		if (canChangeStrong)
		{
			GUI.Box(new Rect(120,10,100,20), "Strong Minion");
			
		}
		
		if (canChangeMini)
		{
			GUI.Box(new Rect(230,10,100,20), "Mini Minion");
			
		}
		
		if (canChangeWizzard)
		{
			GUI.Box(new Rect(10,10,100,20), "Walter");
			
		}
	}
}
