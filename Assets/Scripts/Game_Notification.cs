using UnityEngine;
using System.Collections;

public class Game_Notification : MonoBehaviour {

	public int itemCount;
	public string notice;

	public void notify(){
		gameObject.SetActive (true);
		guiText.text = itemCount.ToString () + notice;
		Invoke ("clear", 5f);
	}

	void clear (){
		gameObject.SetActive (false);
	}

	void Update(){
		if (Screen.showCursor && guiText.text != "") {
			gameObject.SetActive(false);		
		}
	}
}
