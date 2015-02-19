using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool loading = true;
	public GameObject gameMenu;

	public GameObject leaveText;
	public GameObject readTexture;
	public GameObject inventory;
	public GameObject crosshair;
	GameObject controlPlayer;
	GameObject cameraControlCamera;

	public AudioClip pauseSound;
	public AudioClip inventoryOpen;
	public AudioClip inventoryClose;

	void Awake(){
		controlPlayer = GameObject.Find ("Player");
		cameraControlCamera = GameObject.Find ("Main Camera");
	}

	void Start() {
		Invoke ("Done", 2f);
		Game_SaveLoad.lastScene = Application.loadedLevelName;
	}


	public void cursorOn() {
		Screen.showCursor = true;
		Screen.lockCursor = false;
		crosshair.SetActive(false);
		cameraControlCamera.GetComponent<MouseLook>().enabled = false;
		controlPlayer.GetComponent<MouseLook>().enabled = false;
		controlPlayer.GetComponent<CharacterMotor>().enabled = false;
	}


	public void cursorOff() {
		Screen.showCursor = false;
		Screen.lockCursor = true;
		crosshair.SetActive(true);
		cameraControlCamera.GetComponent<MouseLook>().enabled = true;
		controlPlayer.GetComponent<MouseLook>().enabled = true;
		controlPlayer.GetComponent<CharacterMotor> ().enabled = true;
	}
		

	void Update() {
		if(!loading){
				if(Input.GetKeyDown ("i") && !gameMenu.activeSelf && !readTexture.activeSelf && !leaveText.activeSelf){
						if (!inventory.activeSelf) {
								audio.clip = inventoryOpen;
								audio.pitch = Random.Range (0.8f, 1.65f);
								audio.volume = 0.65f;
								audio.Play();
								cursorOn();
								inventory.SetActive (true);
								inventory.GetComponent<Inventory_Load>().fillInventory();
						} 
						else {
								audio.clip = inventoryClose;
								audio.pitch = Random.Range (0.75f, 1.65f);
								audio.volume = 0.2f;
								audio.Play();
								cursorOff();
								inventory.SetActive (false);
						}
				}

				else if (Input.GetKeyDown(KeyCode.Escape) && inventory.activeSelf) {
					audio.clip = inventoryClose;
					audio.pitch = Random.Range (0.75f, 1.65f);
					audio.volume = 0.2f;
					audio.Play();
					cursorOff();
					inventory.SetActive (false);
				}

				else if (Input.GetKeyDown(KeyCode.Escape) && !gameMenu.activeSelf && !readTexture.activeSelf && !leaveText.activeSelf) {
					audio.clip = pauseSound;
					audio.pitch = Random.Range (0.7f, 1.5f);
					audio.volume = 0.8f;
					audio.Play();
					cursorOn();
					gameMenu.SetActive(true);
				}

				else if(Input.GetKeyDown(KeyCode.Escape) && gameMenu.activeSelf && !readTexture.activeSelf && !leaveText.activeSelf){
					audio.clip = pauseSound;
					audio.pitch = Random.Range (0.7f, 1.5f);
					audio.volume = 0.8f;
					audio.Play();
					cursorOff();
					gameMenu.SetActive(false);
				}
		}
	}
	

	void Done(){
		loading = false;
	}
}
