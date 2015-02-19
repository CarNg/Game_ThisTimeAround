using UnityEngine;
using System.Collections;

public class Interactive_Phone : MonoBehaviour {

	bool textMessage = false;

	public Light pulseLight;

	public bool benReply = false;
	public GameObject benText;
	bool benTextRecieved = false;

	public AudioClip vibrate;
	public AudioClip beep;

	void Start () {
		if (Game_SaveLoad.initialScene) {
			Invoke ("GetMessage", 15f);
		}
		else if (!Game_SaveLoad.jayText && !Game_SaveLoad.initialScene){
			textMessage = true;
			gameObject.tag = "Interactable";
		}
	}
	
	void Update () {
		if (textMessage) {
			pulseLight.enabled = enabled;
			pulseLight.intensity = Mathf.PingPong(Time.time * 3, 5);
		}
		else
			pulseLight.enabled = !enabled;
	}

	public void SpecialAction(){
		audio.clip = beep;
		audio.volume = 1;
		audio.Play();
		if (!Game_SaveLoad.jayText) {
			readJayText();
		}
		else if (Game_SaveLoad.jayText && benTextRecieved){
			readBenText();
		}
		else if (benReply){
			textMessage = false;
			gameObject.tag = "Readable";
		}
	}

	public void GetMessage(){
		audio.clip = vibrate;
		audio.volume = 0.2f;
		audio.Play();
		textMessage = true;
		gameObject.tag = "Interactable";
	}

	void readJayText(){
		textMessage = false;
		gameObject.tag = "Readable";
		Game_SaveLoad.jayText = true;
		Game_SaveLoad.Save ();
	}

	void readBenText(){
		benTextRecieved = false;
		textMessage = false;
		benText.SetActive (true);
		Game_SaveLoad.benText = true;
		Game_SaveLoad.Save ();
	}

	public void checkBenText(){
		if (!Game_SaveLoad.benText){
			Invoke ("GetMessage", 3f);
			benTextRecieved = true;
			gameObject.GetComponent<Items_Action>().readItem = false;
		}
	}
}
