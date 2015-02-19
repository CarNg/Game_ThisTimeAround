using UnityEngine;
using System.Collections;

public class Scene_TextStroke : MonoBehaviour {

	public GameObject originalText;
	
	void Update () {
		guiText.text = originalText.GetComponent<GUIText> ().text;
	}
}
