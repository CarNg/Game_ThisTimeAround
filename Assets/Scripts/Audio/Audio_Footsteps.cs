using UnityEngine;
using System.Collections;

public class Audio_Footsteps : MonoBehaviour {

	bool sprint;

	public string material;
	public CharacterController player;
	
	public AudioClip[] concreteSteps;
	public AudioClip[] grassSteps;
	public AudioClip[] gravelSteps;
	public AudioClip[] rugSteps;
	public AudioClip[] tileSteps;
	public AudioClip[] woodSteps;
	public AudioClip[] woodchipSteps;

	void concrete(){
		audio.clip = concreteSteps[Random.Range(0, concreteSteps.Length)];
		audio.pitch = Random.Range (0.8f, 1.3f);
		audio.volume = Random.Range (0.6f, 1f);
		if (!sprint) {
			audio.PlayDelayed(Random.Range (0.18f, 0.35f));
		}
		else
			audio.PlayDelayed(Random.Range (0.07f, 0.25f));
	}

	void grass(){
		audio.clip = grassSteps[Random.Range(0, grassSteps.Length)];
		audio.pitch = Random.Range (0.9f, 1.3f);
		audio.volume = Random.Range (0.1f, 0.25f);
		if (!sprint) {
			audio.PlayDelayed(Random.Range (0.28f, 0.4f));
		}
		else
			audio.PlayDelayed(Random.Range (0.15f, 0.3f));
	}

	void gravel(){
		audio.clip = gravelSteps[Random.Range(0, gravelSteps.Length)];
		audio.pitch = Random.Range (0.8f, 1.3f);
		audio.volume = Random.Range (0.03f, 0.2f);
		if (!sprint) {
			audio.PlayDelayed(Random.Range (0.25f, 0.35f));
		}
		else
			audio.PlayDelayed(Random.Range (0.1f, 0.25f));
	}

	void rug(){
		audio.clip = rugSteps[Random.Range(0, rugSteps.Length)];
		audio.pitch = Random.Range (0.8f, 1.3f);
		audio.volume = Random.Range (0.1f, 0.35f);
		if (!sprint) {
			audio.PlayDelayed(Random.Range (0.08f, 0.2f));
		}
		else
			audio.PlayDelayed(Random.Range (0.01f, 0.15f));
	}

	void tile(){
		audio.clip = tileSteps[Random.Range(0, tileSteps.Length)];
		audio.pitch = Random.Range (0.9f, 1.3f);
		audio.volume = Random.Range (0.2f, 0.45f);
		if (!sprint) {
			audio.PlayDelayed(Random.Range (0.35f, 0.45f));
		}
		else
			audio.PlayDelayed(Random.Range (0.2f, 0.35f));
	}

	void wood(){
		audio.clip = woodSteps[Random.Range(0, woodSteps.Length)];
		audio.pitch = Random.Range (0.8f, 1.3f);
		audio.volume = Random.Range (0.35f, 0.7f);
		if (!sprint) {
			audio.PlayDelayed(Random.Range (0.3f, 0.45f));
		}
		else
			audio.PlayDelayed(Random.Range (0.1f, 0.25f));
	}

	void woodchips(){
		audio.clip = woodchipSteps[Random.Range(0, woodchipSteps.Length)];
		audio.pitch = Random.Range (0.8f, 1.3f);
		audio.volume = Random.Range (0.05f, 0.15f);
		if (!sprint) {
			audio.PlayDelayed(Random.Range (0.2f, 0.3f));
		}
		else
			audio.PlayDelayed(Random.Range (0.02f, 0.2f));
	}

	void Update () {
		if (Input.GetKey("left shift") || Input.GetKey("right shift")) {
			sprint = true;
		}
		else
			sprint = false;

		if (player.velocity.magnitude > 3 && material == "concrete") {
			if(!audio.isPlaying && !Screen.showCursor){
				concrete ();
			}
		}
		else if (player.velocity.magnitude > 3 && material == "grass") {
			if(!audio.isPlaying && !Screen.showCursor){
				grass ();
			}
		}
		else if (player.velocity.magnitude > 3 && material == "gravel") {
			if(!audio.isPlaying && !Screen.showCursor){
				gravel ();
			}
		}
		else if (player.velocity.magnitude > 1 && material == "rug") {
			if(!audio.isPlaying && !Screen.showCursor){
				rug ();
			}
		}
		else if (player.velocity.magnitude > 3 && material == "tile") {
			if(!audio.isPlaying && !Screen.showCursor){
				tile ();
			}
		}
		else if (player.velocity.magnitude > 3 && material == "wood") {
			if(!audio.isPlaying && !Screen.showCursor){
				wood ();
			}
		}
		else if (player.velocity.magnitude > 3 && material == "woodchips") {
			if(!audio.isPlaying && !Screen.showCursor){
				woodchips();
			}
		}
	}
}
