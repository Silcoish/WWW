using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	[SerializeField] bool opened = false;

	Vector3 startPos;
	Vector3 endPos;

	void Start()
	{
		startPos = transform.position;
		endPos = startPos + transform.forward * 5;
	}

	void Update()
	{
		if(opened)
		{
			transform.position = Vector3.Lerp(transform.position, endPos, 3f * Time.deltaTime);
		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, startPos, 3f * Time.deltaTime);
		}
	}

	public void Open()
	{
		opened = true;
		//transform.position = transform.position - transform.forward * 5;
	}

	public void Close()
	{
		opened = false;
		//transform.position = transform.position + transform.forward * 5;
	}
}
