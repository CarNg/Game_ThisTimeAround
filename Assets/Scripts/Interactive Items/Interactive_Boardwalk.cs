using UnityEngine;
using System.Collections;

public class Interactive_Boardwalk : MonoBehaviour {

	GameObject notification;
	
	void Awake(){
		notification = GameObject.Find ("Notification");
	}

	void Start () {
		if(Game_SaveLoad.boardwalk){
			gameObject.tag = "Readable";
			gameObject.GetComponent<Items_ActionText>().actionText = " ";
			notification.GetComponent<Game_Notification>().itemCount += 1;
		}
	}
	
	public void SaveItem(){
		Game_SaveLoad.boardwalk = true;
		Game_SaveLoad.Save ();
		gameObject.tag = "Readable";
		gameObject.GetComponent<Items_ActionText>().actionText = " ";
	}
}
