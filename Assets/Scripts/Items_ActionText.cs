using UnityEngine;
using System.Collections;

public class Items_ActionText : MonoBehaviour {

	public string actionText;
	GameObject crosshairText;
	
	void Awake(){
		crosshairText = GameObject.Find ("Crosshair");
	}

	public void changeText(){
		crosshairText.guiText.text = actionText;
	}
}
