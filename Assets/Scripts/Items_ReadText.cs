using UnityEngine;
using System.Collections;

public class Items_ReadText : MonoBehaviour {
	
	GameObject scene;
	public string textToDisplay;

	void Awake(){
		scene = GameObject.Find ("Scene");
	}

	public void displayText(){

		if(scene.guiText.text == ""){
			scene.GetComponent<Scene_InfoText> ().infoText = textToDisplay;
			scene.GetComponent<Scene_InfoText> ().displayInfoText ();
		}
		scene.guiText.text = "";
		scene.GetComponent<Scene_InfoText> ().infoText = textToDisplay;
		scene.GetComponent<Scene_InfoText> ().displayInfoText ();
	}

}
