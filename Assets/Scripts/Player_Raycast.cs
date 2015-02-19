using UnityEngine;
using System.Collections;

public class Player_Raycast : MonoBehaviour {

	GameObject crosshairText;

	void Awake(){
		crosshairText = GameObject.Find ("Crosshair");
	}

	void Update () {
			Ray ray = camera.ScreenPointToRay(new Vector3(camera.pixelWidth/2, camera.pixelHeight/2, 0));
			RaycastHit hit;

		if (!Screen.showCursor) {
			if (Physics.Raycast(ray, out hit, 3f)){
				
				if(hit.collider.gameObject.tag == "Interactable") {
					hit.collider.gameObject.GetComponent<Items_ActionText>().changeText();
					
					if(Input.GetMouseButton(0)){
						crosshairText.guiText.text = "";
						hit.collider.gameObject.GetComponent<Items_Action>().clickAction();
					}
				}
				
				else if(hit.collider.gameObject.tag == "Readable") {
					crosshairText.guiText.text = " ";
					
					if((hit.collider.gameObject.GetComponent("Items_ActionText") as Items_ActionText) != null){
						hit.collider.gameObject.GetComponent<Items_ActionText>().changeText();
					}
					if(Input.GetMouseButton(0)){
						crosshairText.guiText.text = "";
						hit.collider.gameObject.GetComponent<Items_ReadText>().displayText();
					}
				}
				
				else
					crosshairText.guiText.text = "";	
				
			}
			
			else 
				crosshairText.guiText.text = "";			
		}
	}

}
