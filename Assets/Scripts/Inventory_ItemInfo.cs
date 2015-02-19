using UnityEngine;
using System.Collections;

public class Inventory_ItemInfo : MonoBehaviour {

	public Vector3 originalSize;
	public GameObject information;

	public Texture2D informationTexture;
	public Texture2D colourIcon;
	public Texture2D BWIcon;
	
	void OnMouseDown(){
			information.GetComponent<GUITexture> ().texture = informationTexture;
			audio.pitch = Random.Range (0.8f, 1.8f);
			audio.Play();
			transform.localScale += new Vector3 (0.01f,0.01f,0f);
	}

	void OnMouseUp(){
		transform.localScale = originalSize;
	}

	void Update(){
		if (information.GetComponent<GUITexture> ().texture == informationTexture){
			gameObject.guiTexture.texture = colourIcon;
			gameObject.GetComponent<Inventory_Read>().turnOn = true;
		}
		else if (information.GetComponent<GUITexture> ().texture != informationTexture){
			gameObject.guiTexture.texture = BWIcon;
			gameObject.GetComponent<Inventory_Read>().turnOn = false;
		}
	}
}
