using UnityEngine;
using System.Collections;

public class Scene_InitialOver : MonoBehaviour {
	
	void Awake () {
		Game_SaveLoad.initialScene = false;
		Game_SaveLoad.Save ();
	}

	void Update(){
		if(Input.GetKeyDown ("i") || Input.GetKeyDown(KeyCode.Escape)){
			gameObject.guiText.text = "";
		}
	}
}
