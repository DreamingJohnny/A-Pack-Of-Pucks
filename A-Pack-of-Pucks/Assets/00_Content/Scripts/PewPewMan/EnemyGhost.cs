using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyGhost : MonoBehaviour {

	private List<Transform> cannonNozzles;
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

		Transform[] transforms = GetComponentsInChildren<Transform>();
		cannonNozzles = new List<Transform>();

		//Ensures the list doesn't include the transform on this gameObject
		foreach (Transform transform in transforms) {
			if(transform != gameObject.transform) {
				cannonNozzles.Add(transform);
			}
		}

		Debug.Log($"{cannonNozzles.Count}");
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
							Quaternion.identity);
			}
		}
		else {
			timeSinceShot += Time.deltaTime;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {

	}
}
