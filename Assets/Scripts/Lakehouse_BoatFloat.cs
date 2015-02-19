using UnityEngine;
using System.Collections;

public class Lakehouse_BoatFloat : MonoBehaviour {

	void Update(){
		Vector3 temp = transform.position;
		temp.y += (Mathf.Cos(Time.time * 1f) * 0.001f);
		transform.position = temp;


		Vector3 temp2 = transform.eulerAngles;
		temp2.x += (Mathf.Cos(Time.time * 1f) * 1f);
		transform.eulerAngles = temp2;
	}
}