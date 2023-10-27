using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] private float health;

	public float GetHealth() {
		return health;
	}

	public void SetHealth(float damage) {
		health -= damage;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (!TryGetComponent(out DamageDealer damageDealer)) return;
		else {
			SetHealth(damageDealer.Damage);
		}

		DeathCheck();
	}

	private void DeathCheck() {
		Debug.Log($"{name} is checking its health. Its health is now {GetHealth()}");

		if(health <= 0f) {
			Debug.Log($"{name} has less than zero health and will now be destroyed");
			Destroy(gameObject);
		}
	}
}
