using UnityEngine;
using System.Collections;

public class Scene_QuoteFade : MonoBehaviour {

	public GameObject nextFade;
	
	float time;
	
	void Start(){
		Invoke ("call", 2f);
	}
	
	IEnumerator FadeIn ()
	{	
		while (guiTexture.color.a < 0.6f) {
			Color textureColor = guiTexture.color;
			textureColor.a = Mathf.Lerp(0, 1, 0.15f * time);
			guiTexture.color = textureColor;
			yield return null;
			time += Time.deltaTime;
		}
		
		if (guiTexture.color.a >= 0.5f) {
			nextFade.SetActive (true);
		}
	}
	
	void call(){
		StartCoroutine (FadeIn ());
	}
}
