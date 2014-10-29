using UnityEngine;
using System.Collections;



public class MenuButton : MonoBehaviour {

	public Sprite defaultSprite;
	public Sprite mouseOverSprite;
	public int menuIndex;


	void OnMouseOver () {
		if (this.GetComponent<SpriteRenderer>().sprite != mouseOverSprite) {
			this.GetComponent<SpriteRenderer>().sprite = mouseOverSprite;
		}
	}
	void OnMouseExit () {
		if (this.GetComponent<SpriteRenderer>().sprite != defaultSprite) {
			this.GetComponent<SpriteRenderer>().sprite = defaultSprite;
		}
	}

	void OnMouseDown () {
		Camera.main.SendMessage ("SetActiveMenu", menuIndex);
	}
}
