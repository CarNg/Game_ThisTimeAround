using UnityEngine;
using System.Collections;

public class Audio_Fade : MonoBehaviour {
	
	public float speed;
	public float audioVolume;
	float time = 0;

	public bool fadeDone;

	void Start () {
		fadeDone = false;
		AudioListener.volume = 0;
		audioVolume = PlayerPrefs.GetFloat ("audioVolume");
		StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn()
	{
		while(AudioListener.volume < (audioVolume-0.05f))
		{
			AudioListener.volume = Mathf.Lerp(0f, audioVolume, time * speed);
			yield return null;
			time += Time.deltaTime;
		}
		AudioListener.volume = audioVolume;
		fadeDone = true;
	}
}
