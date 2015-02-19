using UnityEngine;
using System.Collections;

public class Audio_Walking : MonoBehaviour {

	GameObject player;

	public bool exit;
	public string inMaterial;
	public string outMaterial;

	void Awake () {
		player = GameObject.Find ("Player");
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Player") {
			player.GetComponent<Audio_Footsteps>().material = inMaterial;
		}
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.name == "Player") {
			player.GetComponent<Audio_Footsteps>().material = inMaterial;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.name == "Player" && exit) {
			player.GetComponent<Audio_Footsteps>().material = outMaterial;
		}
	}
}
