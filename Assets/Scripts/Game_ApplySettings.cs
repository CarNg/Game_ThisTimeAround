using UnityEngine;
using System.Collections;

public class Game_ApplySettings : MonoBehaviour {

	GameObject player;
	GameObject mainCamera;
	public GameObject scene;

	void Awake(){
		player = GameObject.Find ("Player");
		mainCamera = GameObject.Find ("Main Camera");
	}

	void applySettings(){
		player.GetComponent<MouseLook> ().sensitivity = mainCamera.GetComponent<Game_Settings> ().mouseSensitivity;
		mainCamera.GetComponent<MouseLook> ().sensitivity = mainCamera.GetComponent<Game_Settings> ().mouseSensitivity;

		scene.GetComponent<Scene_InfoText>().textSpeed = mainCamera.GetComponent<Game_Settings>().textSpeed;

		mainCamera.GetComponent<Game_Settings> ().SetState();
	}

}
