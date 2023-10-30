using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Health : MonoBehaviour {

	[SerializeField] private bool shouldShakeCamera = false;
	[Range(0f,10.0f)] [SerializeField] private float shakeDuration;
	[Range(0f,10.0f)] [SerializeField] private float shakeStrength;

	[SerializeField] private ParticleSystem destructionEffect;

	[SerializeField] private float health;

	public float GetHealth() {
		return health;
	}

	public void DecreaseHealth(float damage) {
		health -= damage;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (!TryGetComponent(out DamageDealer damageDealer)) return;

		DecreaseHealth(damageDealer.Damage);

		if (IsDead()) {
			PlayDestructionEffects();
			Destroy(gameObject);
		}
		else if (shouldShakeCamera) CinemachineShake.Instance.ShakeCamera(shakeStrength, shakeDuration);
	}

	private bool IsDead() {

		if (health <= 0f) return true;
		else return false;
	}

	private void PlayDestructionEffects() {
		ParticleSystem instance = Instantiate(destructionEffect, transform.position, Quaternion.identity);

		Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
	}
}
