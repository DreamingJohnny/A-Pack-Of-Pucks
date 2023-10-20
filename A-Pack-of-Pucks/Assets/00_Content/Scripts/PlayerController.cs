using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float speedModifier;

	private Vector2 movement;

	private Rigidbody2D rigidBody2D;

	void Start() {
		rigidBody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		Movement();
	}

	private void Movement() {
		rigidBody2D.AddForce(movement * speedModifier * Time.fixedDeltaTime);
	}

	public void OnMove(InputValue inputValue) {
		movement = inputValue.Get<Vector2>();
	}
}
