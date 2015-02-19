using UnityEngine;
using System.Collections;

public class ColourSwap_Jar : MonoBehaviour {

	public GameObject colourAlt;
	public Light lightOn;
	
	void Start () {
		if(Game_SaveLoad.jar){
			gameObject.SetActive(false);
			colourAlt.SetActive(true);
			if (lightOn != null && !lightOn.enabled){
				lightOn.enabled = true;
			}
		}
	}
}
