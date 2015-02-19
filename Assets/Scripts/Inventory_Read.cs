using UnityEngine;
using System.Collections;

public class Inventory_Read : MonoBehaviour {

	public GameObject fadeObject;
	public GameObject readItem;
	public GameObject inventory;

	public GUISkin menuSkin;
	public Rect readPosition;
	public Texture2D readTexture;

	public bool turnOn;
	public bool fade;

	void OnGUI(){
			GUI.skin = menuSkin;
		if (turnOn) {
			if (GUI.Button(readPosition, "Read")){
				if (fade){
					fadeObject.SetActive (true);
				}
				inventory.SetActive(false);
				readItem.GetComponent<Items_CloseRead>().fromInventory = true;
				readItem.GetComponent<GUITexture>().texture = readTexture;
				readItem.SetActive(true);
			}	
		}
	}
}
