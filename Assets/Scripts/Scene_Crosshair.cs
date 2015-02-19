using UnityEngine;
using System.Collections;

public class Scene_Crosshair : MonoBehaviour {
	
	Texture2D crosshair;
	public Texture2D crosshairDot;
	public Texture2D crosshairRings;

	Rect position;

	float rotAngle = 0;
	Vector2 pivotPoint;

	void Start(){
		crosshair = crosshairDot;
	}

	void Update(){
		position = new Rect ((Screen.width - crosshairDot.width) / 2, (Screen.height - crosshairDot.height) / 2, crosshairDot.width, crosshairDot.height);
	
		if(guiText.text == ""){
			crosshair = crosshairDot;
			rotAngle = 0;
		}
		else
			crosshair = crosshairRings;

		if (crosshair == crosshairRings){
			rotAngle += 0.8f;
		}
	}

	void OnGUI(){
		pivotPoint = new Vector2(Screen.width / 2, Screen.height / 2);
		GUIUtility.RotateAroundPivot(rotAngle, pivotPoint);
		GUI.DrawTexture(position, crosshair);
	}
}