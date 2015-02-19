using UnityEngine;
using System.Collections;

public class Interactive_Plecs : MonoBehaviour {

	GameObject notification;
	
	void Awake(){
		notification = GameObject.Find ("Notification");
	}

	void Start () {
		if(Game_SaveLoad.plecs){
			gameObject.SetActive(false);
			notification.GetComponent<Game_Notification>().itemCount += 1;
		}
	}
	
	public void SaveItem(){
		Game_SaveLoad.plecs = true;
		Game_SaveLoad.Save ();
		gameObject.SetActive(false);
	}
}
