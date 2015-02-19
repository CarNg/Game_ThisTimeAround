using UnityEngine;
using System.Collections;

public class Interactive_Medal : MonoBehaviour {

	GameObject notification;
	
	void Awake(){
		notification = GameObject.Find ("Notification");
	}

	void Start () {
		if(Game_SaveLoad.medal){
			gameObject.SetActive(false);
			notification.GetComponent<Game_Notification>().itemCount += 1;
		}
	}
	
	public void SaveItem(){
		Game_SaveLoad.medal = true;
		Game_SaveLoad.Save ();
		gameObject.SetActive(false);
	}
}
