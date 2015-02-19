using UnityEngine;
using System.Collections;

public class Interactive_Jar : MonoBehaviour {

	public GameObject dirt;
	GameObject notification;
	
	void Awake(){
		notification = GameObject.Find ("Notification");
	}

	void Start () {
		if(Game_SaveLoad.jar){
			dirt.SetActive(true);
			gameObject.tag = "Untagged";
			notification.GetComponent<Game_Notification>().itemCount += 1;
		}
	}
	
	public void SaveItem(){
		Game_SaveLoad.jar = true;
		Game_SaveLoad.Save ();
		dirt.SetActive(true);
		gameObject.tag = "Untagged";
	}
}
