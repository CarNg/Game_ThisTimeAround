using UnityEngine;
using System.Collections;

public class Player_SetPosition : MonoBehaviour {
	
	void Start () {
		if (GameObject.Find ("LoadedLevel") != null) {
			transform.position = new Vector3 (1.6f, 1.85f, 5.15f);
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
			Destroy(GameObject.Find ("LoadedLevel"));
		}
	}
}
