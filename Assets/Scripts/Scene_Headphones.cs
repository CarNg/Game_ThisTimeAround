using UnityEngine;
using System.Collections;

public class Scene_Headphones : MonoBehaviour {

	float time;
	public bool newGame;
	public GameObject quote;
	public GameObject black;
	
	void Start () {
		Invoke ("fadeInCall", 1f);
		Screen.showCursor = false;
		Invoke ("fadeOutCall", 8f);
	}

	void fadeOutCall(){
		if (!newGame) {
			Game_SaveLoad.Load();
			black.GetComponent<Game_MenuFadeOut>().levelToLoad = Game_SaveLoad.lastScene;
			black.SetActive (true);	
		}
		else
			StartCoroutine("FadeOut");  
	}

	void fadeInCall(){
		StartCoroutine ("FadeIn");
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
		if (!newGame) {
			AudioListener.volume = Mathf.Lerp (AudioListener.volume, 0, 0.4f * time);		
		}
		while (guiTexture.color.a > 0.01) {
			Color textureColor = guiTexture.color;
			textureColor.a = Mathf.Lerp(textureColor.a, 0, 1.3f * Time.deltaTime);
			guiTexture.color = textureColor;
			yield return null;
		}
			guiTexture.color = Color.clear;
			quote.SetActive (true);		
	}
}
