using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	[SerializeField] bool isDoorPressurePlate;
	[SerializeField] bool isBarricade;
	[SerializeField] GameObject linkedObject;

	public AudioClip boomBoomShakeTheRoom;
	Vector3 startPos;
	Vector3 endPos;

	float delayCounter = 0f;
	float delayTimer = 0.2f;

	void Start(){
		startPos = transform.position;
		endPos = transform.position - transform.up * 0.05f;
	}

	void Update(){
		delayCounter += Time.deltaTime;
	}

	void OnCollisionEnter(Collision col){
		if(delayCounter > delayTimer)
		{
			if(col.gameObject.tag == "HeavyBox")
			{
				if(isDoorPressurePlate)
				{
					linkedObject.GetComponent<Door>().Open();
					transform.position = endPos;
					delayCounter = 0f;
				}

				if(isBarricade)
				{
					audio.PlayOneShot (boomBoomShakeTheRoom);
					Destroy(linkedObject);
				}
			}
		}
	}

	void OnCollisionExit(Collision col){
		if(delayCounter > delayTimer)
		{
			if(col.gameObject.tag == "HeavyBox")
			{
				if(isDoorPressurePlate)
				{
					linkedObject.GetComponent<Door>().Close();
					transform.position = startPos;
					delayCounter = 0f;
				}
			}
		}
	}
}
