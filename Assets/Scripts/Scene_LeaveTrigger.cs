using UnityEngine;
using System.Collections;

public class Scene_LeaveTrigger : MonoBehaviour {
	
	public GameObject leaveText;
	public GameObject gameController;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			audio.Play();
			leaveText.SetActive(true);
			gameController.GetComponent<GameController> ().cursorOn();
		}
	}
}
