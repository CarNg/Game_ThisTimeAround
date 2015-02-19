using UnityEngine;
using System.Collections;

public class Interactive_Present : MonoBehaviour {

	public GameObject openPresent;

	void Start(){
		if (Game_SaveLoad.present) {
			transform.position = new Vector3 (6.600536f, 1.823022f, -2.051487f);
			backToRead();
		}
		else if (Game_SaveLoad.birthdayCard) {
			gameObject.tag = "Interactable";		
		}

		if (!Game_SaveLoad.openPresent && Game_SaveLoad.parkFinished && Game_SaveLoad.lakeFinished && Game_SaveLoad.present) {
			Invoke ("narrativeMention", 5f);
		}
	}

	public void SpecialAction(){
		audio.Play ();
		Game_SaveLoad.present = true;
		Game_SaveLoad.Save ();
		gameObject.GetComponent<Items_ReadText> ().textToDisplay = "I'm so sick of this!";
		gameObject.GetComponent<Items_ReadText> ().displayText ();
		rigidbody.AddForce(80, 15, 70);
		gameObject.tag = "Untagged";
		Invoke ("reaction", 3f);
		if (!Game_SaveLoad.openPresent && Game_SaveLoad.parkFinished && Game_SaveLoad.lakeFinished && Game_SaveLoad.present) {
			gameObject.tag = "Untagged";
			openPresent.collider.enabled = true;
		}
	}

	void reaction(){
		gameObject.GetComponent<Items_ReadText> ().textToDisplay = "Every time he bails there's some lame excuse and \n" +
			"he thinks some stupid present will make it better.";
		gameObject.GetComponent<Items_ReadText> ().displayText ();
		Invoke ("backToRead", 10f);
	}

	void backToRead(){
		gameObject.GetComponent<Items_ActionText> ().actionText = "0pen Present";
		gameObject.GetComponent<Items_ReadText> ().textToDisplay = "I  don't want to deal with that right now.";
		gameObject.tag = "Readable";
	}

	void narrativeMention(){
		gameObject.tag = "Untagged";
		gameObject.GetComponent<Items_ReadText> ().textToDisplay = "I hope I didn't break anything in it.";
		gameObject.GetComponent<Items_ReadText>().displayText();
		openPresent.collider.enabled = true;
	}
}
