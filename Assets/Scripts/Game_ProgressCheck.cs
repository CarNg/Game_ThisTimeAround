using UnityEngine;
using System.Collections;

public class Game_ProgressCheck : MonoBehaviour {

	public GameObject phone;

	void Start () {
		if (!Game_SaveLoad.parkFinished && Game_SaveLoad.picnicBench && Game_SaveLoad.polaroid && Game_SaveLoad.pond && Game_SaveLoad.kite) {
				Game_SaveLoad.jayText = true;
				Game_SaveLoad.parkFinished = true;
				Game_SaveLoad.Save();
				if(!Game_SaveLoad.lakeFinished){
					phone.GetComponent<Interactive_Phone>().checkBenText();
				}
		}

		if (!Game_SaveLoad.lakeFinished && Game_SaveLoad.boardwalk && Game_SaveLoad.jar && Game_SaveLoad.plecs && Game_SaveLoad.medal) {
				Game_SaveLoad.jayText = true;
				Game_SaveLoad.lakeFinished = true;
				Game_SaveLoad.Save();
				if(!Game_SaveLoad.parkFinished){
					phone.GetComponent<Interactive_Phone>().checkBenText();
				}
		}

		if (!Game_SaveLoad.openPresent && Game_SaveLoad.parkFinished && Game_SaveLoad.lakeFinished) {
			Invoke ("narrativeMention", 5f);
		}
	}

	void narrativeMention(){
		gameObject.GetComponent<Items_ReadText>().displayText();
	}
}
