using UnityEngine;
using System.Collections;

public class Interactive_PostIt : MonoBehaviour {

	void SpecialAction(){
		if (!audio.isPlaying){
				audio.pitch = Random.Range (0.75f, 1.5f);
				audio.Play ();
		}
	}
}
