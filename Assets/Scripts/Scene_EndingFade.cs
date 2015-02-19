using UnityEngine;
using System.Collections;

public class Scene_EndingFade : MonoBehaviour {

	public bool end;
	public bool credits;
	public float creditsLength;
	public GameObject nextCredit;

	float time;
	public float startDelay;

	public GameObject continueObject;
	public float continueDelay;
	public int continueButton;

	void Start(){
		Invoke ("fadeInCall", startDelay);
	}
	
	IEnumerator FadeIn ()
	{	
		while (guiTexture.color.a < 0.5f) {
			Color textureColor = guiTexture.color;
			textureColor.a = Mathf.Lerp(0, 1, 0.15f * time);
			guiTexture.color = textureColor;
			yield return null;
			time += Time.deltaTime;
		}
		
		if (guiTexture.color.a >= 0.4f) {
			if (end){
				Invoke ("endGame", creditsLength);
			}
			else if(credits){
				Invoke ("fadeOutCall", creditsLength);	
			}
			else
				Invoke ("continueButtonCall", continueDelay);
		}
	}

	IEnumerator FadeOut ()
	{	
		while (guiTexture.color.a > 0.01) {
			Color textureColor = guiTexture.color;
			textureColor.a = Mathf.Lerp(textureColor.a, 0, 1.3f * Time.deltaTime);
			guiTexture.color = textureColor;
			yield return null;
		}
			gameObject.SetActive (false);
			if (credits) {
				nextCredit.SetActive (true);		
			}
	}
	
	void fadeInCall(){
		StartCoroutine (FadeIn ());
	}

	public void fadeOutCall(){
		StartCoroutine (FadeOut ());
	}

	void endGame(){
		continueObject.GetComponent<Scene_Ending> ().EndScene ();
	}
	
	void continueButtonCall(){
		if (continueButton == 3) {
			continueObject.GetComponent<Scene_Ending>().FadeEndButton();
			continueObject.GetComponent<Scene_Ending> ().buttonFunction = continueButton;
		}
		else
			continueObject.GetComponent<Scene_Ending>().FadeContButton();
			continueObject.GetComponent<Scene_Ending> ().buttonFunction = continueButton;
	}
}
