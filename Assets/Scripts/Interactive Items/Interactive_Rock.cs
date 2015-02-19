using UnityEngine;
using System.Collections;

public class Interactive_Rock : MonoBehaviour {

	public GameObject plecs;

	void Start(){
		if (Game_SaveLoad.rock) {
			transform.position = new Vector3(44.6f, 2.15f, 44.1f);
			gameObject.tag = "Untagged";
			Invoke ("turnOnCollider", 0.5f);
		}
	}

	public void SpecialAction(){
		Game_SaveLoad.rock = true;
		Game_SaveLoad.Save ();
		transform.position = new Vector3(44.6f, 2.15f, 44.1f);
		gameObject.tag = "Untagged";
		Invoke ("turnOnCollider", 0.5f);
	}

	void turnOnCollider(){
		if(plecs.activeSelf){
			plecs.collider.enabled = true;
		}
	}
}
