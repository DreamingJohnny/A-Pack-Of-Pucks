using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewShot : MonoBehaviour {

	[SerializeField] private float speed;

	//Amount of time in s that the projectile shoud exist for.
	[SerializeField] private float lifeTime;
	private float timeLived;

	private void OnEnable() {
		timeLived = 0f;
	}

	private void Update() {
		Movement();

		CheckLifeTime();
	}

	/// <summary>
	/// Checks how long the projectile has been instantiated for, and destroys it when it's lived beyond lifeTime
	/// </summary>
	private void CheckLifeTime() {
		if(timeLived <= lifeTime) {
			timeLived += Time.deltaTime;
		} else {
			Destroy(gameObject);
		}
	}

	private void Movement() {
		transform.position = Vector3.MoveTowards(transform.position,
												target: new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),
												speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log($"{name} collided with {collision.gameObject.name}.");
	}
}
