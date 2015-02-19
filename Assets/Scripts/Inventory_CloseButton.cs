using UnityEngine;
using System.Collections;

public class Inventory_CloseButton : MonoBehaviour {

	public GUISkin menuSkin;
	GameObject gameController;

	void Awake(){
		gameController = GameObject.Find ("Game Controller");
	}

	void OnGUI(){
		GUI.skin = menuSkin;

		if (GUI.Button(new Rect (880, 710, 120, 40), "Close")){
			audio.pitch = Random.Range (0.75f, 1.65f);
			audio.Play();
			Invoke ("delay", 0.5f);
		}
	}
	
	void Update(){
			if(Input.GetKeyDown(KeyCode.Escape)){
				audio.pitch = Random.Range (0.75f, 1.65f);
				audio.Play();
				Invoke ("delay", 0.5f);
			}
	}
	
	void delay(){
		gameController.GetComponent<GameController> ().cursorOff ();
		gameObject.SetActive(false);
	}
}
