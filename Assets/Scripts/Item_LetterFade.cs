using UnityEngine;
using System.Collections;

public class Item_LetterFade : MonoBehaviour {

	float time;
	public float duration;

	void OnEnable () {
		AudioListener.pause = true;
		audio.ignoreListenerPause = true;
		audio.Play ();
		Screen.showCursor = false;
		StartCoroutine (FadeIn ());
		Invoke ("button", duration);
	}

	IEnumerator FadeIn ()
	{	
		while (guiTexture.color.a < 0.5f) {
			Color textureColor = guiTexture.color;
			textureColor.a = Mathf.Lerp(0, 0.6f, 0.1f * time);
			guiTexture.color = textureColor;
			yield return null;
			time += Time.deltaTime;
		}					
	}

	void button(){
		Screen.showCursor = true;
		AudioListener.pause = false;
		transform.parent.GetComponent<Items_CloseRead> ().fadeInButton ();
		transform.parent.GetComponent<Items_CloseRead> ().fading = false;
	}

	void disable(){
		gameObject.SetActive (false);
	}
}
