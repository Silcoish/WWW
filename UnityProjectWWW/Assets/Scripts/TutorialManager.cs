using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {

	public static TutorialManager tutManager;

	// 0 = walter
	// 1 = strong
	// 2 = mini
	bool[] firstTimeTuts;

	public void Awake()
	{
		tutManager = this;
	}

}
