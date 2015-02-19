using UnityEngine;
using System.Collections;

public class Scene_Ending : MonoBehaviour {

	public GUISkin menuSkin;
	public int buttonFunction;

	public GameObject noteToDad;
	public GameObject letterToMum;
	public GameObject quote;
	public GameObject credit;

	LTRect continueButton = new LTRect (880, 710, 120, 40, 0);
	LTRect endButton = new LTRect (429.5f, 680, 165, 40, 0);

	void Start () {
		AudioListener.volume = 1;
		Screen.lockCursor = false;
		Screen.showCursor = false;
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		StartCoroutine(FadeToClear());  
	}

	void OnGUI(){
		GUI.skin = menuSkin;
		if(buttonFunction == 1){
			if (GUI.Button(continueButton.rect, "Continue")){
				LeanTween.alpha (continueButton, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
				noteToDad.GetComponent<Scene_EndingFade>().fadeOutCall();
				audio.pitch = Random.Range (0.9f, 1.5f);
				audio.Play();
				Screen.showCursor = false;
				letterToMum.SetActive (true);
			}
		}
		else if (buttonFunction == 2){
			if (GUI.Button(continueButton.rect, "Continue")){
				LeanTween.alpha (continueButton, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
				letterToMum.GetComponent<Scene_EndingFade>().fadeOutCall();
				audio.pitch = Random.Range (0.9f, 1.5f);
				audio.Play();
				Screen.showCursor = false;
				quote.SetActive (true);
			}
		}
		else if (buttonFunction == 3){
			if (GUI.Button(endButton.rect, "The End")){
				LeanTween.alpha (endButton, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
				quote.GetComponent<Scene_EndingFade>().fadeOutCall();
				audio.pitch = Random.Range (0.9f, 1.5f);
				audio.Play();
				Screen.showCursor = false;
				credit.SetActive(true);
			}
		}
	}

	public void FadeContButton(){
		Screen.showCursor = true;
		LeanTween.alpha (continueButton, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
		LeanTween.alpha (continueButton, 1f, 1f).setEase (LeanTweenType.easeInQuad);
	}

	public void FadeEndButton(){
		Screen.showCursor = true;
		LeanTween.alpha (endButton, 0f, 1f).setEase (LeanTweenType.easeOutQuad);
		LeanTween.alpha (endButton, 1f, 1f).setEase (LeanTweenType.easeInQuad);
	}

	IEnumerator FadeToClear ()
	{	
		while (guiTexture.color.a > 0.01) {
			guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, 0.4f * Time.deltaTime);
			yield return null;
		}
		
		if (guiTexture.color.a <= 0.03f) {
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
		}
		
	}
	
	public void EndScene () {	
		guiTexture.enabled = true;
		StartCoroutine(FadeToEnd());  
	}

	void loadLevel(){
		Application.LoadLevel ("Opening");
	}

	IEnumerator FadeToEnd ()
	{	
		Screen.showCursor = false;
		
		while (guiTexture.color.a < 0.6f) {
			guiTexture.color = Color.Lerp (guiTexture.color, Color.black, 0.3f * Time.deltaTime);
			yield return null;
		}
		
		if (guiTexture.color.a >= 0.5f) {
			Invoke ("loadLevel", 8f);
		}
	}
}
