using UnityEngine;
using System.Collections;

public class Audio_Transients : MonoBehaviour {

	public AudioClip[] sfxArray;

	public float minTime;
	public float maxTime;

	public float maxVol;
	
	void Start(){
		InvokeRepeating("transientAudio", Random.Range(minTime, maxTime), Random.Range(minTime, maxTime));
	}

	void transientAudio(){
		if(!audio.isPlaying){
			audio.clip = sfxArray[Random.Range (0, sfxArray.Length)];
			audio.volume = Random.Range (0.01f, maxVol);
			audio.Play();
		}
	}

}
