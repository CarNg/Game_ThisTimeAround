using UnityEngine;
using System.Collections;

public class Player_Sprint : MonoBehaviour {

	float speed;
	float walkSpeed = 7;
	float runSpeed = 10f;
	
	CharacterMotor chMotor;
	
	void Start () 
	{
		Screen.lockCursor = true;
		Screen.showCursor = false;
		chMotor =  gameObject.GetComponent<CharacterMotor>();
		chMotor.movement.maxForwardSpeed = speed;
	}
	
	void FixedUpdate () {
		chMotor.movement.maxForwardSpeed = speed;

		if (Input.GetKey("left shift") || Input.GetKey("right shift")) {
			speed = runSpeed;
		}
		else
			speed = walkSpeed;
	}
}
