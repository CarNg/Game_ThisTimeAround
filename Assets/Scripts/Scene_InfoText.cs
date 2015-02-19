using UnityEngine;
using System.Collections;

public class Scene_InfoText : MonoBehaviour {

	public string infoText;
	public int textSpeed;

	public GameObject menu;
	public GameObject inventory;
	public GameObject readTexture;
	public GameObject settings;

	public void displayInfoText(){
		if(menu.activeSelf || inventory.activeSelf || readTexture.activeSelf || settings.activeSelf){
			guiText.text = "";
		}
		else {
			CancelInvoke("clearInfoText");
			guiText.text = infoText;
			Invoke ("clearInfoText", textSpeed);
		}
	}

	public void clearInfoText(){
			guiText.text = "";
	}

	void Start(){
		textSpeed = PlayerPrefs.GetInt("textSpeed");
	}

	void Update(){
		if(menu.activeSelf || inventory.activeSelf || readTexture.activeSelf || settings.activeSelf){
			guiText.text = "";
		}
	}
}
