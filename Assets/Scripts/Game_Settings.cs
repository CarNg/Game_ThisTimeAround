using UnityEngine;
using System.Collections;

public class Game_Settings : MonoBehaviour {

	public float mouseSensitivity;
	public int textSpeed;
	public float audioVolume;

	void Awake(){
		GetState ();
	}

	public void GetState(){
		if(PlayerPrefs.HasKey("audioVolume")){
			audioVolume = PlayerPrefs.GetFloat("audioVolume");
			mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity");
			textSpeed = PlayerPrefs.GetInt("textSpeed");
		}
		else
			setDefault();
	}

	public void SetState(){
		PlayerPrefs.SetFloat ("audioVolume", audioVolume);
		PlayerPrefs.SetFloat("mouseSensitivity", mouseSensitivity);
		PlayerPrefs.SetInt("textSpeed", textSpeed);
		PlayerPrefs.Save();
	}

	void setDefault(){
		PlayerPrefs.SetFloat ("audioVolume", 1);
		PlayerPrefs.SetFloat("mouseSensitivity", 3);
		PlayerPrefs.SetInt("textSpeed", 8);
		PlayerPrefs.Save();
		audioVolume = PlayerPrefs.GetFloat("audioVolume");
		mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity");
		textSpeed = PlayerPrefs.GetInt("textSpeed");
	}
}
