using UnityEngine;
using System.Collections;

public class Game_MainMenu : MonoBehaviour {

	float time;

	public GUISkin menuSkin;
	public GUIStyle disabledButton;

	public GameObject background;
	public GameObject settingsMenu;
	public GameObject noSaveFile;
	public GameObject headphonesScreen;
	public GameObject mainCamera;

	LTRect newButtonFade = new LTRect (313, 520, 175, 45, 0);

	void Start(){
		AudioListener.volume = mainCamera.GetComponent<Game_Settings>().audioVolume;
		fadeInMenu ();
		Screen.showCursor = true;
		Game_SaveLoad.Check ();
	}

	void OnGUI () {

		GUI.skin = menuSkin;

			if(GUI.Button(newButtonFade.rect, "New Game")) {
				fadeOutMenu();
				mainCamera.audio.pitch = Random.Range (0.9f, 1.5f);
				mainCamera.audio.Play();
				headphonesScreen.GetComponent<Scene_Headphones>().newGame = true;
				headphonesScreen.SetActive (true);
			}

			if(GUI.Button(new Rect (194.5f, 600, 175, 50), "Settings")) {
				mainCamera.audio.pitch = Random.Range (0.9f, 1.5f);
				mainCamera.audio.Play();
				settingsMenu.SetActive (true);
				gameObject.SetActive (false);
			}

			if(GUI.Button(new Rect (424.5f, 600, 175, 45), "Credits")) {
				fadeOutMenu();
				Screen.showCursor = false;
				background.SetActive (false);
				mainCamera.audio.pitch = Random.Range (0.9f, 1.5f);
				mainCamera.audio.Play();
				Invoke ("credits", 3f);
			}

			if(GUI.Button(new Rect (654.5f, 600, 160, 45), "Quit")) {
				fadeOutMenu();
				mainCamera.audio.pitch = Random.Range (0.9f, 1.5f);
				mainCamera.audio.Play();
				Invoke ("quit", 1f);
			}

			if (Game_SaveLoad.savedData){
				if(GUI.Button(new Rect (536, 520, 175, 45), "Continue")) {
					fadeOutMenu();
					mainCamera.audio.pitch = Random.Range (0.9f, 1.5f);
					mainCamera.audio.Play();
					headphonesScreen.SetActive (true);
				}
			}
			else {
				if(GUI.Button(new Rect (536, 520, 175, 45), "Continue", disabledButton)) {
					noSaveFile.SetActive (true);
					Invoke ("clear", 2.5f);
				}
			}
	}

	void fadeInMenu(){
		StartCoroutine ("FadeIn");
		LeanTween.alpha (newButtonFade, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
		LeanTween.alpha (newButtonFade, 1f, 1f).setEase (LeanTweenType.easeInQuad);
	}
	
	void fadeOutMenu(){
		StartCoroutine ("FadeOut");
		LeanTween.alpha (newButtonFade, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
	}

	IEnumerator FadeIn ()
	{	
		while (guiTexture.color.a < 0.6f) {
			Color textureColor = guiTexture.color;
			textureColor.a = Mathf.Lerp(0, 1, 0.3f * time);
			guiTexture.color = textureColor;
			yield return null;
			time += Time.deltaTime;
		}
		
		if (guiTexture.color.a > 0.5f) {
			Color textureColor = guiTexture.color;
			textureColor.a = 0.6f;
			guiTexture.color = textureColor;
			time = 0;
		}
	}
	
	IEnumerator FadeOut ()
	{	
		while (guiTexture.color.a > 0.01) {
			Color textureColor = guiTexture.color;
			textureColor.a = Mathf.Lerp(textureColor.a, 0, 1.9f * Time.deltaTime);
			guiTexture.color = textureColor;
			yield return null;
		}
		gameObject.SetActive (false);
	}

	void clear(){
		noSaveFile.SetActive (false);
	}

	void quit(){
		Application.Quit();
	}

	void credits(){
		Application.LoadLevel ("Credits");
	}
}
