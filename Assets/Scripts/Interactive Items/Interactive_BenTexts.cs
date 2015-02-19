using UnityEngine;
using System.Collections;

public class Interactive_BenTexts : MonoBehaviour {

	int steps;
	public GUISkin menuSkin;

	public Texture2D replyOptions;
	public Texture2D niceReply;
	public Texture2D meanReply;
	public Texture2D benNiceReply;
	public Texture2D benMeanReply;

	public GameObject phone;
	public GameObject scene;
	public GameObject gameController;

	void Start () {
		steps = 0;
		scene.guiText.text = "";
		gameController.GetComponent<GameController>().cursorOn();
	}
	
	void OnGUI(){
		GUI.skin = menuSkin;
		if (steps == 0) {
			if (GUI.Button(new Rect (880, 710, 110, 40), "Reply")){
				audio.Play();
				steps += 1;
				guiTexture.texture = replyOptions;
			}
		}
		else if (steps == 1) {
			if (GUI.Button(new Rect (665, 650, 110, 40), "Send")){
				audio.Play();
				steps = 2;
				guiTexture.texture = meanReply;
			}

			if (GUI.Button(new Rect (265, 650, 110, 40), "Send")){
				audio.Play();
				steps = 3;
				guiTexture.texture = niceReply;
			}
		}
		else if (steps == 2){
			if (GUI.Button(new Rect (880, 710, 120, 40), "Close")){
				audio.Play();
				Invoke ("close", 0.1f);
				Invoke ("sendMeanReply", 3f);
			}
		}
		else if (steps == 3){
			if (GUI.Button(new Rect (880, 710, 120, 40), "Close")){
				audio.Play();
				Invoke ("close", 0.1f);
				Invoke ("sendNiceReply", 3f);
			}
		}
	}

	void close(){
		phone.GetComponent<Interactive_Phone> ().tag = "Readable";
		gameController.GetComponent<GameController> ().cursorOff ();
		gameObject.SetActive(false);
	}

	void sendNiceReply(){
		phone.GetComponent<Interactive_Phone> ().benReply = true;
		phone.GetComponent<Interactive_Phone> ().GetMessage();
		phone.GetComponent<Items_Action> ().readItem = true;
		phone.GetComponent <Items_Action> ().readTexture = benNiceReply;
	}

	void sendMeanReply(){
		phone.GetComponent<Interactive_Phone> ().benReply = true;
		phone.GetComponent<Interactive_Phone> ().GetMessage();
		phone.GetComponent<Items_Action> ().readItem = true;
		phone.GetComponent <Items_Action> ().readTexture = benMeanReply;
	}
}
