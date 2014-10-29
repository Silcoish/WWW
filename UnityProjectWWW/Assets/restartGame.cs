using UnityEngine;
using System.Collections;

public class restartGame : MonoBehaviour {

	float counter = 0f;
	float timer = 10f;

	void Update () {
		counter += Time.deltaTime;
		if(counter >= timer)
		{
			Application.LoadLevel(0);
		}
	}
}
