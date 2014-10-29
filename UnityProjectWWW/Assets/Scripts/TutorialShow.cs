using UnityEngine;
using System.Collections;

public class TutorialShow : MonoBehaviour {

	bool seen = false;
	[SerializeField] GameObject tutorial;
	[SerializeField] GameObject gameDirector;

	bool startedTimer = false;
	float counter = 0;
	float timer = 0.3f;

	void Update()
	{
		if(startedTimer)
		{
			counter += Time.deltaTime;
		}

		if(counter > timer)
		{
			tutorial.SetActive(false);
			gameDirector.GetComponent<GameDirector>().showingTutorial = false;
		}

		if(Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.JoystickButton0))
		{
			if(seen){
				startedTimer = true;
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			if(!seen)
			{
				tutorial.SetActive(true);
				seen = true;
				gameDirector.GetComponent<GameDirector>().showingTutorial = true;
			}
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			tutorial.SetActive(false);
			gameDirector.GetComponent<GameDirector>().showingTutorial = false;
		}
	}
}
