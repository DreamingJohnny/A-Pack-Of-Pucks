using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : MonoBehaviour {

	private Transform[] cannonNozzles;
	[SerializeField] private GameObject enemyShot;
	[SerializeField] private float reloadTime;
	private float timeSinceShot;

	//Also, what to do if it gets hit by a player controlled shot

	[SerializeField] private float speed;

	public float Speed { get { return speed; } }

	private void OnEnable() {
		timeSinceShot = 0f;
		InitCannons();
	}

	private void InitCannons() {
		cannonNozzles = GetComponentsInChildren<Transform>();
	}

	void Update() {
		Shoot();
	}

	private void Shoot() {
		if (reloadTime <= timeSinceShot) {
			timeSinceShot = 0f;
			foreach (Transform transform in cannonNozzles) {
				Instantiate(enemyShot, 
							transform.position,
							Quaternion.identity,
							transform);
			}
		}
		else {
			timeSinceShot += Time.deltaTime;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {

	}
}
