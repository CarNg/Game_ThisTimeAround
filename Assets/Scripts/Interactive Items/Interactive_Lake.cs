using UnityEngine;
using System.Collections;

public class Interactive_Lake : MonoBehaviour {

	public GameObject gameController;

	public GameObject scene;
	
	public GameObject plane;
	public Texture2D colourAlt;

	void Start(){
		Invoke ("check", 1f);
	}

	public void SpecialAction(){
		if (!Game_SaveLoad.parkVisited) {
			audio.Play();
			Game_SaveLoad.lakeVisited = true;
			Game_SaveLoad.Save ();
			gameController.GetComponent<GameController> ().cursorOn();
			Screen.showCursor = false;
			scene.GetComponent<Scene_Fade> ().levelToLoad = "Lakehouse";
			scene.GetComponent<Scene_Fade>().EndScene();
		}
		
		else if (Game_SaveLoad.parkFinished) {
			audio.Play();
			Game_SaveLoad.lakeVisited = true;
			Game_SaveLoad.Save ();
			gameController.GetComponent<GameController> ().cursorOn();
			Screen.showCursor = false;
			scene.GetComponent<Scene_Fade> ().levelToLoad = "Lakehouse";
			scene.GetComponent<Scene_Fade>().EndScene();
		}
		
		else
			gameObject.GetComponent<Items_ReadText>().displayText();
	}

	void check(){
		if (Game_SaveLoad.lakeFinished){
			plane.renderer.material.mainTexture = colourAlt;
			gameObject.GetComponent<Items_ActionText>().actionText = "It's been a while since we've been";
		}
	}
}
