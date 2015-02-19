using UnityEngine;
using System.Collections;

public class Interactive_ExplanationLetter : MonoBehaviour {

	public GameObject giftBox;
	GameObject notification;
	
	void Awake(){
		notification = GameObject.Find ("Notification");
	}

	void Start () {
		if(Game_SaveLoad.explanationLetter){
			gameObject.SetActive(false);
			notification.GetComponent<Game_Notification>().itemCount += 1;
		}
	}
	
	void SaveItem(){
		Game_SaveLoad.explanationLetter = true;
		giftBox.tag = "Interactable";
		Game_SaveLoad.Save ();
		gameObject.SetActive(false);
	}
	
}