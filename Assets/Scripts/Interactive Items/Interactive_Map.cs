using UnityEngine;
using System.Collections;

public class Interactive_Map : MonoBehaviour {

	GameObject notification;
	public GameObject scene;
	public GameObject sprintInstructions;

	void Awake(){
		notification = GameObject.Find ("Notification");
	}

	void Start () {
		if(!Game_SaveLoad.map){
			Invoke ("displayText", 1f);
			Invoke ("clearText", 10f);
			if(!Game_SaveLoad.parkVisited){
				Invoke ("instructions", 25f);
			}
		}
		else
			notification.GetComponent<Game_Notification>().itemCount += 1;
			gameObject.SetActive (false);
	}

	void displayText(){
		scene.guiText.text = "We've spent so many summers by the lake. This place \n"
			+ "holds more memories than I could possibly recall.";
	}

	void clearText(){
		scene.guiText.text = "";
		gameObject.GetComponent<Items_Action>().clickAction();
		Game_SaveLoad.map = true;
		Game_SaveLoad.Save ();
		gameObject.SetActive(false);
	}

	void instructions(){
		sprintInstructions.SetActive (true);
	}

	void Update(){
		if (Screen.showCursor) {
			CancelInvoke();
			scene.guiText.text = "";
			Game_SaveLoad.map = true;
			Game_SaveLoad.Save ();
			notification.GetComponent<Game_Notification>().itemCount += 1;
			gameObject.SetActive(false);
		}
	}
}
