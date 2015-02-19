using UnityEngine;
using System.Collections;

public class Player_DontDestroy : MonoBehaviour {
	
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}

}
