using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeRotator : MonoBehaviour {
	//So, I need to get mouse position, and "up" on the maze, and then distance in between, as angle, and rotate based on that.
	private Quaternion rotation;

	//These should probably become degrees in the end...
	private Vector2 mousePosition;
	private Vector2 startMousePosition;
	private Vector2 currentMousePosition;


	private bool shouldRotate;

	void Start() {

	}

	void Update() {
	
	}

	private void FixedUpdate() {
		if (shouldRotate) {
			RotateMaze();
		}
	}

	private void RotateMaze() {
		currentMousePosition = Input.mousePosition;

		Quaternion quaternion = 
			//Mathf.LerpAngle

		transform.Rotate();

		Debug.Log(mousePosition);

		//So, I want to take mouse position on started, and on performed, and take the difference, and then I want to apply the difference,
		//So,

	}

	public void OnRotate(InputAction.CallbackContext context) {

		if(context.started) {
			shouldRotate = true;
			startMousePosition = Input.mousePosition;
		}
		else if (context.canceled) {
			shouldRotate = false;
			startMousePosition = Vector2.zero;
		}		
	}
}
