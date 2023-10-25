using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Point : MonoBehaviour {

	//String used to check tags on collision.
	[SerializeField] private string playerTag = "Player";

	public UnityEvent OnPointCollect;

	//If the point has been taken and should currently be gone.
	private bool isActive;
	//The timespan that the point should be gone for
	[SerializeField] private float timeToSpendInactive = 10f;
	private float timeSinceActive;

	private void Start() {
		isActive = true;
		timeSinceActive = 0f;
	}

	private void Update() {
		if (isActive) return;

		if (timeSinceActive >= timeToSpendInactive) {
			ActivatePoint(true);
		}
		else {
			timeSinceActive += Time.deltaTime;
		}
	}

	private void ActivatePoint(bool value) {
		isActive = value;
		timeSinceActive = 0f;
		GetComponent<SpriteRenderer>().enabled = value;
		GetComponent<CircleCollider2D>().enabled = value;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.CompareTag(playerTag)) {
			OnPointCollect.Invoke();

			ActivatePoint(false);
		}
	}
}
