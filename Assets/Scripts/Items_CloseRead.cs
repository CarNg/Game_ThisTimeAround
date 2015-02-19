using UnityEngine;
using System.Collections;

public class Items_CloseRead : MonoBehaviour {

	public GameObject initialScene;
	public Texture2D bdayCardInfo;

	public bool fading = false;
	GameObject gameController;
	public GUISkin menuSkin;

	public bool fromInventory;
	public GameObject inventory;

	public AudioClip paperClose;
	public AudioClip cardClose;

	public Texture2D jayText;
	public Texture2D benNiceReply;
	public Texture2D benMeanReply;
	public AudioClip phoneClose;

	public bool addedToInventory;
	GameObject notification;

	LTRect closeButton = new LTRect (880, 710, 120, 40, 0);
	
	void Awake(){
		gameController = GameObject.Find ("Game Controller");
		notification = GameObject.Find ("Notification");
	}
	
	void OnGUI(){
		GUI.skin = menuSkin;
		if(!fading && !fromInventory){
			if (GUI.Button(closeButton.rect, "Close")){
				if(addedToInventory){
					Invoke ("notify", 0.5f);
				}

				if (initialScene != null && gameObject.guiTexture.texture == bdayCardInfo){
					audio.clip = cardClose;
					audio.volume = 0.25f;
					audio.Play();
					Invoke ("Instructions", 1f);
					Invoke ("close", 0.4f);
				}
				else if (gameObject.guiTexture.texture == jayText || gameObject.guiTexture.texture == benMeanReply || gameObject.guiTexture.texture == benMeanReply){
						audio.clip = phoneClose;
						audio.volume = 1f;
						audio.Play();
						Invoke ("close", 0.1f);
				}
				else
					audio.pitch = Random.Range (0.75f, 1.5f);
					audio.Play();
					Invoke ("close", 0.4f);
			}
			Screen.showCursor = true;
		}
		else if (fromInventory){
			if (GUI.Button(new Rect (880, 710, 120, 40), "Back")){
				if (gameObject.guiTexture.texture == bdayCardInfo){
					audio.clip = cardClose;
					audio.volume = 0.25f;
					audio.Play();
					Invoke ("back", 0.4f);
				}
				else
					audio.clip = paperClose;
					audio.pitch = Random.Range (0.75f, 1.5f);
					audio.Play();
					Invoke ("back", 0.4f);
			}
			Screen.showCursor = true;
		}
		else {
			Screen.showCursor = false;
		}
	}
	
	void Update(){
		if(!fading){
			if(Input.GetKeyDown(KeyCode.Escape)){
				if(!fromInventory){
						Screen.showCursor = true;

						if(addedToInventory){
							Invoke ("notify", 0.5f);
						}
						
						if (initialScene != null && gameObject.guiTexture.texture == bdayCardInfo){
							audio.clip = cardClose;
							audio.volume = 0.25f;
							audio.Play();
							Invoke ("Instructions", 1f);
							Invoke ("close", 0.4f);
						}
						else if (gameObject.guiTexture.texture == jayText || gameObject.guiTexture.texture == benMeanReply || gameObject.guiTexture.texture == benMeanReply){
							audio.clip = phoneClose;
							audio.volume = 1f;
							audio.Play();
							Invoke ("close", 0.1f);
						}
						else {
							audio.pitch = Random.Range (0.75f, 1.5f);
							audio.Play();
							Invoke ("close", 0.4f);
						}
				}

				else if (fromInventory){
						Screen.showCursor = true;

						if (gameObject.guiTexture.texture == bdayCardInfo) {
							audio.clip = cardClose;
							audio.volume = 0.25f;
							audio.Play();
							Invoke ("back", 0.4f);
						}
						else {
							audio.clip = paperClose;
							audio.pitch = Random.Range (0.75f, 1.5f);
							audio.Play();
							Invoke ("back", 0.4f);
						}
				}

				else
					Screen.showCursor = false;
			}
		}
	}

	public void fadeInButton (){
		LeanTween.alpha (closeButton, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
		LeanTween.alpha (closeButton, 1f, 1f).setEase (LeanTweenType.easeInQuad);
	}
	
	void Instructions(){
		initialScene.guiText.text = "You can open your sketchbook by pressing I.";
		audio.clip = paperClose;
		audio.volume = 1f;
	}

	void notify(){
		notification.GetComponent<Game_Notification>().itemCount += 1;
		notification.GetComponent<Game_Notification> ().notify ();
		addedToInventory = false;
	}

	void close(){
		BroadcastMessage("disable");
		gameController.GetComponent<GameController> ().cursorOff ();
		gameObject.SetActive(false);
	}

	void back(){
		BroadcastMessage("disable");
		gameObject.SetActive (false);
		inventory.SetActive (true);
		fromInventory = false;
		AudioListener.pause = false;
	}

}
