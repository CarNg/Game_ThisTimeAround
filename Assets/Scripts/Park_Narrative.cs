using UnityEngine;
using System.Collections;

public class Park_Narrative : MonoBehaviour {

	public GameObject scene;
	public GameObject sprintInstructions;

	void Start () {
		if (!Game_SaveLoad.parkVisited) {
			Invoke ("displayText", 1f);
			Invoke ("clearText", 18f);
			Game_SaveLoad.parkVisited = true;
			Game_SaveLoad.Save ();
			if (!Game_SaveLoad.lakeVisited) {
				Invoke("instructions", 20f);
			}
		}
	}

	void displayText(){
		scene.guiText.text = "This is where we would spend time as a family. It's also where \n" +
			"M um and Dad would go when they were dating. I met Jay here too.";
	}

	void clearText(){
		scene.guiText.text = "";
	}

	void instructions(){
		sprintInstructions.SetActive(true);
	}
}
