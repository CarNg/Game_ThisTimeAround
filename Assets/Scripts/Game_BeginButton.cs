using UnityEngine;
using System.Collections;

public class Game_BeginButton : MonoBehaviour {

	float time;
	bool ready = false;
	public GUISkin menuSkin;
	public GameObject black;

	LTRect continueButton = new LTRect (850, 705, 150, 35, 0);

	void Start(){
		Invoke ("call", 3f);
	}

	void OnGUI(){
		GUI.skin = menuSkin;

		if (ready) {
			if(GUI.Button(continueButton.rect, "Continue")) {
				fadeOut();
			}	
		}
	}

	IEnumerator FadeIn ()
	{	
		while (guiTexture.color.a < 0.6f) {
			Color textureColor = guiTexture.color;
			textureColor.a = Mathf.Lerp(0, 1, 0.2f * time);
			guiTexture.color = textureColor;
			yield return null;
			time += Time.deltaTime;
		}

		if (guiTexture.color.a >= 0.5f) {
			Invoke ("button", 3f);
		}
	}

	void call(){
		StartCoroutine (FadeIn ());
	}

	void button(){
		LeanTween.alpha (continueButton, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
		LeanTween.alpha (continueButton, 1f, 1f).setEase (LeanTweenType.easeInQuad);
		ready = true;
		Screen.showCursor = true;
	}

	void fadeOut(){
		Screen.showCursor = false;
		LeanTween.alpha (continueButton, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
		black.GetComponent<Game_MenuFadeOut> ().levelToLoad = "Bedroom (From Dream)";
		black.SetActive (true);
	}
}
