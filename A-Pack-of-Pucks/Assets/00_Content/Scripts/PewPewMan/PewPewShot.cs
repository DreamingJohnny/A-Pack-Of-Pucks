using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewShot : MonoBehaviour {

	[SerializeField] private float speed;

	private void Start() {

	}

	private void Update() {
		Movement();
	}

	private void Movement() {
		transform.position = Vector3.MoveTowards(transform.position, target: new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log($"{name} collided with {collision.gameObject.name}.");
	}
}
