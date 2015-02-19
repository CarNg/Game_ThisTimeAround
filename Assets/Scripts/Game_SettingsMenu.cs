using UnityEngine;
using System.Collections;

public class Game_SettingsMenu : MonoBehaviour {

	GameObject mainCamera;

	bool controls;
	public Texture2D menuBKD;
	public Texture2D controlsBKD;

	public bool mainMenu;
	public GUISkin menuSkin;
	public GameObject background;

	float mouseSensitivity;
	int textSpeed;
	string[] selStrings = new string[] {"Slow", "Medium", "Fast"};
	public float audioVolume;
	
	void Awake(){
		mainCamera = GameObject.Find ("Main Camera");
	}

	void Start(){
		controls = false;
		audioVolume = mainCamera.GetComponent<Game_Settings>().audioVolume;

		mouseSensitivity = mainCamera.GetComponent<Game_Settings>().mouseSensitivity;
		
		if(mainCamera.GetComponent<Game_Settings>().textSpeed == 13){
			textSpeed = 0;
		}
		else if(mainCamera.GetComponent<Game_Settings>().textSpeed == 8){
			textSpeed = 1;
		}
		else
			textSpeed = 2;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Cancel();
		}
	}

	void Confirm(){
		mainCamera.GetComponent<Game_Settings> ().audioVolume = audioVolume;

		mainCamera.GetComponent<Game_Settings>().mouseSensitivity = mouseSensitivity;

		if(textSpeed == 0){
			mainCamera.GetComponent<Game_Settings>().textSpeed = 13;
		}
		else if(textSpeed == 1){
			mainCamera.GetComponent<Game_Settings>().textSpeed = 8;
		}
		else
			mainCamera.GetComponent<Game_Settings>().textSpeed = 5;

		mainCamera.GetComponent<Game_Settings> ().SetState ();

		if(!mainMenu){
			BroadcastMessage("applySettings");
		}

		background.SetActive (true);
		gameObject.SetActive (false);
	}

	void Cancel(){
		audioVolume = PlayerPrefs.GetFloat ("audioVolume");
		AudioListener.volume = audioVolume;

		mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity");
		
		if(PlayerPrefs.GetInt("textSpeed") == 13){
			textSpeed = 0;
		}
		else if(PlayerPrefs.GetInt("textSpeed") == 8){
			textSpeed = 1;
		}
		else
			textSpeed = 2;

		background.SetActive (true);
		gameObject.SetActive (false);
	}
	
	void OnGUI () {
		GUI.skin = menuSkin;

		if (!controls) {
			if (GUI.Button(new Rect (440, 170, 180, 48), "Controls")){
				audio.pitch = Random.Range (0.7f, 1.5f);
				audio.Play();
				controls = true;
				gameObject.guiTexture.texture = controlsBKD;
			}

			GUI.Label (new Rect (260, 240, 210, 50), "Audio Volume");
			audioVolume = GUI.HorizontalSlider(new Rect (560, 260, 200, 10), audioVolume, 0f, 1f);
			AudioListener.volume = audioVolume;

			GUI.Label (new Rect (260, 330, 210, 50), "Mouse Sensitivity");
			mouseSensitivity = GUI.HorizontalSlider (new Rect (560, 350, 200, 10), mouseSensitivity, 0.5f, 10f);
			
			GUI.Label (new Rect (260, 420, 210, 50), "Text Speed");
			textSpeed = GUI.SelectionGrid(new Rect (500, 425, 325, 35), textSpeed, selStrings, 3);

			if (GUI.Button(new Rect (570, 520, 125, 45), "Accept")){
				audio.pitch = Random.Range (0.7f, 1.5f);
				audio.Play();
				Invoke ("Confirm", 0.15f);
			}
			
			if (GUI.Button(new Rect (360, 520, 125, 45), "Cancel")){
				audio.pitch = Random.Range (0.7f, 1.5f);
				audio.Play();
				Invoke ("Cancel", 0.15f);
			}		
		}
		else
			if (GUI.Button(new Rect (449.5f, 600, 135, 45), "Back")){
				audio.pitch = Random.Range (0.7f, 1.5f);
				audio.Play();
				controls = false;
				gameObject.guiTexture.texture = menuBKD;
			}
	}
}
