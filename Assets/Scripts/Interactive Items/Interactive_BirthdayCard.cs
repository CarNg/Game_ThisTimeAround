using UnityEngine;
using System.Collections;

public class Interactive_BirthdayCard : MonoBehaviour {

	GameObject notification;
	public GameObject present;

	void Awake(){
		notification = GameObject.Find ("Notification");
	}
	
	void Start () {
		if(Game_SaveLoad.birthdayCard){
			gameObject.SetActive(false);
			notification.GetComponent<Game_Notification>().itemCount += 1;
		}
	}

	public void SaveItem(){
		audio.Play ();
		Game_SaveLoad.birthdayCard = true;
		Game_SaveLoad.Save ();
		Invoke ("changePresent", 3);
		Invoke ("delayInactive", 0.3f);
	}

	void delayInactive(){
		gameObject.SetActive(false);
	}

	void changePresent(){
		present.tag = "Interactable";
	}
}
