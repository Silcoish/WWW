using UnityEngine;
using System.Collections;

public class TutorialShow : MonoBehaviour {

	bool seen = false;
	[SerializeField] GameObject tutorial;

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			if(!seen)
			{
				tutorial.SetActive(true);
				seen = true;
			}
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			tutorial.SetActive(false);
		}
	}
}
