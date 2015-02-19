using UnityEngine;
using System.Collections;

public class Scene_LeaveText : MonoBehaviour {

	public GUISkin menuSkin;

	public string question;
	public string location;
	
	public GameObject endScene; 
	public GameObject gameController;

	void cancel(){
		gameObject.SetActive (false);
		gameController.GetComponent<GameController> ().cursorOff();
	}

	void clear(){
		gameObject.SetActive (false);
	}

	void OnGUI(){
		GUI.skin = menuSkin;

		GUI.Label (new Rect ((Screen.width/2) - 150, (Screen.height/2) - 120, 300, 35), question);

		if (GUI.Button (new Rect ((Screen.width/2) - 75, (Screen.height/2) - 40, 150, 40), "Yeah")) {
			Invoke("clear", 1f);

			if (location == "Home"){
				audio.PlayDelayed (0.6f);
				endScene.GetComponent<Scene_Fade> ().levelToLoad = "Bedroom";
				endScene.GetComponent<Scene_Fade> ().EndScene ();
			}
			else if(!Game_SaveLoad.giftBox && location == "Bedroom"){
				audio.PlayDelayed (0.8f);
				endScene.GetComponent<Scene_Fade> ().levelToLoad = "Bedroom (From Dream)";
				endScene.GetComponent<Scene_Fade> ().EndScene ();
			}
			else {
				audio.PlayDelayed (0.8f);
				endScene.GetComponent<Scene_Fade> ().levelToLoad = location;
				endScene.GetComponent<Scene_Fade> ().EndScene ();
			}
		}

		if (GUI.Button (new Rect ((Screen.width/2) - 75, (Screen.height/2) + 20, 150, 40), "Nevermind")){
			audio.Play();
			Invoke("cancel", 0.4f);
		}

	}

	void Update() {

		if (Input.GetKeyDown(KeyCode.Escape) && gameObject.activeSelf) {
			audio.Play();
			Invoke("cancel", 0.4f);
		}

	}
}
