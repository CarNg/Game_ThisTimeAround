using UnityEngine;
using System.Collections;

public class Interactive_Pond : MonoBehaviour {

	GameObject notification;

	void Awake(){
		notification = GameObject.Find ("Notification");
	}

	void Start () {
		if(Game_SaveLoad.pond){
			gameObject.tag = "Readable";
			gameObject.GetComponent<Items_ActionText> ().actionText = " ";
			notification.GetComponent<Game_Notification>().itemCount += 1;
		}
	}
	
	public void SaveItem(){
		Game_SaveLoad.pond = true;
		Game_SaveLoad.Save ();
		gameObject.tag = "Readable";
		gameObject.GetComponent<Items_ActionText> ().actionText = " ";
	}
}
