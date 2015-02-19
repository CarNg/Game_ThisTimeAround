using UnityEngine;
using System.Collections;

public class ColourSwap_Example : MonoBehaviour {
	
	public GameObject colourAlt;
	public Light lightOn;

	void Start () {
		if(Game_SaveLoad.birthdayCard){
			gameObject.SetActive(false);
			colourAlt.SetActive(true);
			if (lightOn != null){
				lightOn.enabled = true;
			}
		}
	}

}
