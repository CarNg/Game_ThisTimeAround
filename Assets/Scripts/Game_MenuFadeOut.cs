using UnityEngine;
using System.Collections;

public class Game_MenuFadeOut : MonoBehaviour {

	float time;
	public string levelToLoad;

	void Start () {
		StartCoroutine ("FadeIn");
	}
	
	IEnumerator FadeIn ()
	{	
		while (guiTexture.color.a < 0.6f) {
			AudioListener.volume = Mathf.Lerp (AudioListener.volume, 0, 0.4f * time);
			Color textureColor = guiTexture.color;
			textureColor.a = Mathf.Lerp(0, 1, 0.4f * time);
			guiTexture.color = textureColor;
			yield return null;
			time += Time.deltaTime;
		}
		
		if (guiTexture.color.a > 0.5f) {
			AudioListener.volume = 0f;
			Application.LoadLevel (levelToLoad);
		}
	}
}
