using UnityEngine;
using System.Collections;

public class Interactive_Kite : MonoBehaviour {

	GameObject notification;
	
	void Awake(){
		notification = GameObject.Find ("Notification");
	}

	void Start () {
		if(Game_SaveLoad.kite){
			gameObject.tag = "Readable";
			gameObject.GetComponent<Items_ActionText> ().actionText = " ";
			notification.GetComponent<Game_Notification>().itemCount += 1;
		}
	}
	
	public void SaveItem(){
		Game_SaveLoad.kite = true;
		Game_SaveLoad.Save ();
		gameObject.tag = "Readable";
		gameObject.GetComponent<Items_ActionText> ().actionText = " ";
	}

}
