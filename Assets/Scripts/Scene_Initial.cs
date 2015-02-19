using UnityEngine;
using System.Collections;

public class Scene_Initial : MonoBehaviour {

	GameObject player;
	public GameObject scene;
	int textSpeed;

	void Awake(){
		textSpeed = scene.GetComponent<Scene_InfoText> ().textSpeed;
		player = GameObject.Find ("Player");
	}

	void Start () {
		if (Game_SaveLoad.initialScene) {
			Invoke ("displayText", 3);
			Invoke ("clearText", 3 + textSpeed);
			Invoke ("zoomInstructions", 6 + textSpeed);
		}
		else
			player.transform.position = new Vector3 (-7f, 1.83f, 4.8f);
			player.transform.rotation = Quaternion.Euler(new Vector3(0, 20, 0));
	}

	void Update(){
		if (Input.GetMouseButton(1) || Input.GetKeyDown ("i") || Input.GetKeyDown(KeyCode.Escape)) {
			gameObject.guiText.text = "";
		}
	}
	
	void zoomInstructions(){
		gameObject.guiText.text = "Right click to zoom.";
	}

	void displayText(){
		scene.GetComponent<GUIText> ().text = "That was a weird dream. \n" +
										"Dad said he'd make breakfast today, I wonder what he's making.";
	}

	void clearText(){
		scene.GetComponent<GUIText> ().text = "";
	}
}
