using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour {

	public static TutorialManager tutManager;

	public enum tutorialStates
	{
		WALTER = 0,
		STRONG = 1,
		MINI = 2,
		JUMP = 3,
		ENUM_LENGTH = 4
	}

	bool[] firstTimeTuts;
	[SerializeField] Dictionary<string, int> dictionary;

	public void Awake()
	{
		tutManager = this;
	}

	public void Start()
	{
		firstTimeTuts = new bool[(int)tutorialStates.ENUM_LENGTH];
	}

	public void ShowTutorial(tutorialStates state)
	{
		if(firstTimeTuts[(int)state] == false)
		{
			print ("Winn");
			firstTimeTuts[(int)state] = true;
		}
	}

}
