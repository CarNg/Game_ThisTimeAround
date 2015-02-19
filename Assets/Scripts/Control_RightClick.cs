using UnityEngine;
using System.Collections;

public class Control_RightClick : MonoBehaviour {

	void Update () {
		if (Input.GetMouseButton(1))
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 30, 2 * Time.deltaTime);
		else 
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, 2 * Time.deltaTime);
	}
}
