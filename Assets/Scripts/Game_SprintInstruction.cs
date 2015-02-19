using UnityEngine;
using System.Collections;

public class Game_SprintInstruction : MonoBehaviour {

	public GameObject scene;
	
	void Start () {
		gameObject.guiText.text = "Hold shift to walk faster";
	}
	
	void Update(){
		if (Screen.showCursor || Input.GetKey("left shift") || Input.GetKey("right shift")) {
			gameObject.SetActive (false);	
		}
	}
}
