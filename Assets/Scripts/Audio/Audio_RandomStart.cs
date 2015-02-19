using UnityEngine;
using System.Collections;

public class Audio_RandomStart : MonoBehaviour {

	float startPoint;
	public float maxTime;

	// Use this for initialization
	void Awake () {
		startPoint = Random.Range (0.0f, maxTime);
		audio.time = startPoint;
		audio.Play ();
	}
}
