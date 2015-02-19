using UnityEngine;
using System.Collections;

public class Scene_Fade : MonoBehaviour
{
	GameObject gameController;
	GameObject mainCamera;
	
	public float fadeInSpeed;
	public float fadeOutSpeed;	
	public string levelToLoad;
	GameObject crosshair;

	public float audioFadeSpeed;
	public float audioVolume;
	float time = 0;

	void Awake(){
		gameController = GameObject.Find ("Game Controller");
		crosshair = GameObject.Find ("Crosshair");
		mainCamera = GameObject.Find ("Main Camera");
	}

	void Start ()
	{	
		gameController.GetComponent<GameController> ().cursorOn ();
		Screen.showCursor = false;

		AudioListener.volume = 0;
		audioVolume = mainCamera.GetComponent<Game_Settings>().audioVolume;
		StartCoroutine(FadeAudioIn());

		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		StartCoroutine(FadeToClear());  
	}

	void loadDelay(){
		AudioListener.volume = 0f;
		Application.LoadLevel (levelToLoad);
	}
	
	IEnumerator FadeToBlack ()
	{	
		crosshair.SetActive (false);
		yield return new WaitForSeconds(1);
		Screen.showCursor = false;

		while (guiTexture.color.a < 0.6f) {
			guiTexture.color = Color.Lerp (guiTexture.color, Color.black, fadeOutSpeed * Time.deltaTime);
			yield return null;
		}

		if (guiTexture.color.a >= 0.5f) {
			Invoke("loadDelay", 1f);
		}

	}

	IEnumerator FadeToClear ()
	{	
		while (guiTexture.color.a > 0.05) {
			guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeInSpeed * Time.deltaTime);
			yield return null;
		}
		
		if (guiTexture.color.a <= 0.1f) {
			gameController.GetComponent<GameController> ().cursorOff ();
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
		}
	}
	
	public void EndScene ()
	{	
		gameObject.guiText.text = "";
		gameController.GetComponent<GameController> ().loading = true;
		guiTexture.enabled = true;
		StartCoroutine(FadeToBlack());  
	}

	IEnumerator FadeAudioIn()
	{
		while(AudioListener.volume < (audioVolume-0.05f))
		{
			AudioListener.volume = Mathf.Lerp(0f, audioVolume, time * audioFadeSpeed);
			yield return null;
			time += Time.deltaTime;
		}
		AudioListener.volume = audioVolume;
	}
}