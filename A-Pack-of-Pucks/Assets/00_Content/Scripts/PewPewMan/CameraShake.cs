using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	[SerializeField] private float shakeDuration = 2f;
	[SerializeField] private float shakeRadius = 0.5f;

	private Vector3 cameraNeutralPosition;

	Rigidbody2D rigidBody;

	void Start() {
		cameraNeutralPosition = transform.position;
		rigidBody = GetComponent<Rigidbody2D>();
	}

	public void Shake() {

		StartCoroutine(ShakeCamera());
	}

	private IEnumerator ShakeCamera() {

		float timeShaken = 0f;

		while (timeShaken <= shakeDuration) {
			
			timeShaken += Time.deltaTime;
			transform.position = (cameraNeutralPosition + ((Vector3)Random.insideUnitCircle * shakeRadius));
			yield return new WaitForEndOfFrame();
		}

		transform.position = cameraNeutralPosition;
	}
}
