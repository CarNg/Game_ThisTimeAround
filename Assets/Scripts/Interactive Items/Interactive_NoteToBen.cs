using UnityEngine;
using System.Collections;

public class Interactive_NoteToBen : MonoBehaviour {

	public GameObject scene;

	void SpecialAction(){
		Game_SaveLoad.lastScene = "Kitchen";
		Game_SaveLoad.Save ();
		scene.GetComponent<Scene_Fade> ().levelToLoad = "Ending";
		scene.GetComponent<Scene_Fade>().EndScene();
	}
}
