using UnityEngine;
using System.Collections;

public class Interactive_Park : MonoBehaviour {

	public GameObject gameController;
	public GameObject scene;
	
	public GameObject plane;
	public Texture2D colourAlt;
	
	void Start(){
		Invoke ("check", 1f);
	}

	public void SpecialAction(){
		if (!Game_SaveLoad.lakeVisited) {
			audio.Play();
			gameController.GetComponent<GameController> ().cursorOn();
			scene.GetComponent<Scene_Fade> ().levelToLoad = "Park";
			scene.GetComponent<Scene_Fade>().EndScene();
		}

		else if (Game_SaveLoad.lakeFinished) {
			audio.Play();
			gameController.GetComponent<GameController> ().cursorOn();
			scene.GetComponent<Scene_Fade> ().levelToLoad = "Park";
			scene.GetComponent<Scene_Fade>().EndScene();
		}

		else
			gameObject.GetComponent<Items_ReadText>().displayText();
	}

	void check(){
		if (Game_SaveLoad.parkFinished){
			plane.renderer.material.mainTexture = colourAlt;
			gameObject.GetComponent<Items_ActionText>().actionText = "I run to the park quite often";
		}
	}
}
