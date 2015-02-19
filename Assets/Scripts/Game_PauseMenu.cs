using UnityEngine;
using System.Collections;

public class Game_PauseMenu : MonoBehaviour {

	public GUISkin menuSkin;
	public GameObject settingsMenu;

	GameObject scene;
	public GameObject gameController;

	LTRect buttonFade = new LTRect (437, 250, 175, 45, 0);

	void Awake(){
		scene = GameObject.Find ("Scene");
		LeanTween.alpha (buttonFade, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
		LeanTween.alpha (buttonFade, 1f, 1f).setEase (LeanTweenType.easeInQuad);
	}

	void Start(){
		guiTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
	}

	void OnGUI () {

		GUI.skin = menuSkin;

		if (GUI.Button(buttonFade.rect, "Resume")){
			audio.pitch = Random.Range (0.7f, 1.5f);
			audio.Play();
			Invoke ("resume", 0.15f);
		}

		if(GUI.Button(new Rect (437, 310, 175, 45), "Settings")) {
			audio.pitch = Random.Range (0.7f, 1.5f);
			audio.Play();
			Invoke ("settings", 0.15f);
		}

		if(GUI.Button(new Rect(428, 370, 200, 48), "Main Menu")) {
			audio.pitch = Random.Range (0.7f, 1.5f);
			audio.Play();
			Invoke ("mainMenu", 0.15f);
		}

		if(GUI.Button(new Rect (414, 433, 220, 45), "Save and Quit")) {
			audio.pitch = Random.Range (0.7f, 1.5f);
			audio.Play();
			Invoke ("quit", 0.15f);
		}
	}

	void mainMenu(){
		Game_SaveLoad.Save();
		reset ();
		scene.GetComponent<Scene_Fade> ().levelToLoad = "Opening";
		scene.GetComponent<Scene_Fade> ().EndScene ();
		Invoke ("delayFade", 0.8f);
	}

	void delayFade(){
		LeanTween.alpha (buttonFade, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
	}

	void resume(){
		gameObject.SetActive(false);
		gameController.GetComponent<GameController> ().cursorOff();
	}

	void settings(){
		settingsMenu.SetActive (true);
		gameObject.SetActive (false);
	}

	void quit(){
		Game_SaveLoad.lastScene = Application.loadedLevelName;
		Game_SaveLoad.Save ();
		scene.GetComponent<Scene_Fade> ().levelToLoad = "";
		scene.GetComponent<Scene_Fade> ().EndScene ();
		Invoke ("delayFade", 0.8f);
		Application.Quit();
	}

	void reset(){
		Game_SaveLoad.jayText = false;
		Game_SaveLoad.initialScene = true;
		Game_SaveLoad.benText = false;
		
		Game_SaveLoad.birthdayCard = false;
		Game_SaveLoad.present = false;
		Game_SaveLoad.openPresent = false;
		Game_SaveLoad.explanationLetter = false;
		Game_SaveLoad.giftBox = false;
		
		Game_SaveLoad.lakeVisited = false;
		Game_SaveLoad.map = false;
		Game_SaveLoad.boardwalk = false;
		Game_SaveLoad.medal = false;
		Game_SaveLoad.rock = false;
		Game_SaveLoad.plecs = false;
		Game_SaveLoad.jar = false;
		Game_SaveLoad.lakeFinished = false;
		
		Game_SaveLoad.parkVisited = false;
		Game_SaveLoad.picnicBench = false;
		Game_SaveLoad.polaroid = false;
		Game_SaveLoad.pond = false;
		Game_SaveLoad.kite = false;
		Game_SaveLoad.parkFinished = false;
	}
}
