using UnityEngine;
using System.Collections;

public class ColourSwap_LakeVisited : MonoBehaviour {

	public GameObject colourAlt;
	public Light lightOn;
	
	void Start () {
		if(Game_SaveLoad.lakeVisited){
			gameObject.SetActive(false);
			colourAlt.SetActive(true);
			if (lightOn != null && !lightOn.enabled){
				lightOn.enabled = true;
			}
		}
	}

}
