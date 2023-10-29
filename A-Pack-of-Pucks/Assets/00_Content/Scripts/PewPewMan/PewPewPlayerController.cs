using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PewPewPlayerController : MonoBehaviour {

	Rigidbody2D rigidBody;
	private Vector2 movement;
	//The speed with which the ship moves
	[SerializeField] private float speed;

	private Shooter shooter;

	void Start() {
		InitPewPewBody();
		InitShooter();
	}

	private void InitShooter() {
		if(TryGetComponent(out shooter)) {

		}
		else {
			Debug.Log($"{name} couldn't find the shooter component.");
		}
	}

	private void InitPewPewBody() {
		if (!TryGetComponent(out rigidBody)) {
			Debug.Log($"{gameObject.name} is lacking a rigidbody2D component.");
		}
	}

	void Update() {

	}

	private void FixedUpdate() {
		Movement();
	}

	private void Movement() {
		rigidBody.AddForce(speed * Time.deltaTime * movement);
	}

	private void OnMove(InputValue value) {
		movement = value.Get<Vector2>();
	}

	private void OnFire(InputValue value) {

		shooter.Fire(value.isPressed);
	}
}
