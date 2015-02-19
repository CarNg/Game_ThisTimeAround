using UnityEngine;
using System.Collections;

public class Interactive_OpenPresent : MonoBehaviour {

	public GameObject noteToBen;
	public GameObject easel;
	public GameObject player;
	public GameObject present;
	 
	void Start () {
		if(Game_SaveLoad.openPresent){
			gameObject.SetActive(false);
			present.SetActive (false);
			easel.SetActive (true);
			noteToBen.collider.enabled = true;
		}
	}

	public void SpecialAction(){
		audio.Play ();
		player.transform.position = new Vector3 (4.17f, 1.81f, -2.12f);
		player.transform.rotation = Quaternion.Euler(new Vector3(0, 93, 0));
		Game_SaveLoad.openPresent = true;
		Game_SaveLoad.Save ();
		easel.SetActive (true);
		noteToBen.collider.enabled = true;
		Invoke ("delay", 0.3f);
	}

	void delay(){
		gameObject.SetActive(false);
		present.SetActive (false);
	}
}
