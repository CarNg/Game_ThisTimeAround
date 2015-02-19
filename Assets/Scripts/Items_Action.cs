using UnityEngine;
using System.Collections;

public class Items_Action : MonoBehaviour {
	
	public bool readItem;
	public bool addToInventory;
	public bool specialAction;

	public bool fadeAudio;
	public GameObject fadeObject;

	GameObject gameController;

	public GameObject readItemTexture;
	public Texture2D readTexture;
	
	void Awake(){
		gameController = GameObject.Find ("Game Controller");
	}

	public void clickAction(){
		if (specialAction) {
			BroadcastMessage("SpecialAction");
		}

		if (readItem) {
			if (fadeAudio){
				fadeObject.SetActive (true);
				readItemTexture.GetComponent<Items_CloseRead>().fading = true;
			}
			gameController.GetComponent<GameController>().cursorOn();
			readItemTexture.GetComponent<GUITexture>().texture = readTexture;
			readItemTexture.SetActive(true);
		}

		if(addToInventory){
			BroadcastMessage("SaveItem");
			readItemTexture.GetComponent<Items_CloseRead>().addedToInventory = true;
		}
	}

}
