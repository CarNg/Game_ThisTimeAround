using UnityEngine;
using System.Collections;

public class Audio_OutInVol : MonoBehaviour {

	public float indoorsVol;
	public float outdoorsVol;

	float time;
	public AudioClip unfiltered;
	public AudioClip filtered;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Player")
		{
			audio.volume = indoorsVol;

			if (filtered != null){
				time= audio.time;
				audio.clip = filtered;
				audio.time = time;
				audio.Play();
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.name == "Player")
		{
			audio.volume = outdoorsVol;

			if (filtered != null){
				time = audio.time;
				audio.clip = unfiltered;
				audio.time = time;
				audio.Play();
			}
		}
	}
}
