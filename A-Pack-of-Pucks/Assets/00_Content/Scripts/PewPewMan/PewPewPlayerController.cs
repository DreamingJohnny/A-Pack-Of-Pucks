using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PewPewPlayerController : MonoBehaviour {

	//The gameobject that will be spawned on fire
	[SerializeField] private GameObject pewPewShot;

	//Where the shots will be spawned from
	[SerializeField] private Transform[] cannonNozzles;

	Rigidbody2D rigidBody;
	private Vector2 movement;
	//The speed with which the ship moves
	[SerializeField] private float speed;

	void Start() {
		InitPewPewBody();
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
		foreach (Transform transform in cannonNozzles) {
			Instantiate(pewPewShot, 
						transform.position,
						Quaternion.identity);
		}
	}
}
