using UnityEngine;
using System.Collections;

public class Interactive_PlaySound: MonoBehaviour {

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			if (!audio.isPlaying){
				audio.pitch = Random.Range (0.75f, 1.5f);
				audio.Play ();
			}
		}
	}
}
