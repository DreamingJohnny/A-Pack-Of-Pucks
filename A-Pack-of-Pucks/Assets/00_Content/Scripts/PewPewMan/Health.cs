using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] private ParticleSystem destructionEffect;

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

		if(health <= 0f) {
			PlayDestructionEffects();
			Destroy(gameObject);
		}
	}

	private void PlayDestructionEffects() {
		ParticleSystem instance = Instantiate(destructionEffect, transform.position, Quaternion.identity);

		Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
	}
}
