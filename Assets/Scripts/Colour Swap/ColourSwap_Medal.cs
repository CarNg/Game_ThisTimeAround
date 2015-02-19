using UnityEngine;
using System.Collections;

public class ColourSwap_Medal : MonoBehaviour {

	public GameObject colourAlt;
	public Light lightOn;
	
	void Start () {
		if(Game_SaveLoad.medal){
			gameObject.SetActive(false);
			colourAlt.SetActive(true);
			if (lightOn != null && !lightOn.enabled){
				lightOn.enabled = true;
			}
		}
	}
}
