using UnityEngine;
using System.Collections;

public class EndLevelItem_Bouncy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player"){
			Application.LoadLevel(1);
		}


	}

	void FixedUpdate(){
		if(this.rigidbody.velocity.y == 0){
			this.rigidbody.AddForce(new Vector3(0,3,0), ForceMode.Impulse);
		}
	}


}
