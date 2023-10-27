using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballhoost : MonoBehaviour {

	[SerializeField] private string playerTag = "Player";

	void Start() {

	}
	void Update() {

	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.CompareTag("Player")) {
			Debug.Log($"Ballhoost collided with the tag: {playerTag}" );
		}
	}
}
