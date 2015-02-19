using UnityEngine;
using System.Collections;

public class Interactive_GiftBox : MonoBehaviour {

	public GameObject loadedLevel;
	public GameObject scene;
	public GameObject gameController;

	void Start () {
		if(Game_SaveLoad.giftBox){
			gameObject.SetActive(false);
		}
		else if (Game_SaveLoad.explanationLetter){
			gameObject.tag = "Interactable";
		}
	}
	
	public void SpecialAction(){
		if (!audio.isPlaying) {
			audio.Play();
		}
		loadedLevel.SetActive (true);
		Game_SaveLoad.giftBox = true;
		Game_SaveLoad.Save ();
		Invoke ("delay", 0.13f);
	}

	void delay(){
		scene.GetComponent<Scene_Fade> ().levelToLoad = "Bedroom";
		scene.GetComponent<Scene_Fade>().EndScene();
	}
}
