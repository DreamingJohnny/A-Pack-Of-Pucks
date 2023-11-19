using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class Health : MonoBehaviour {

	public event EventHandler OnKilled;

	public event EventHandler<OnDamagedEventArgs> OnDamaged;
	public class OnDamagedEventArgs : EventArgs {
		public float Health;
	}

	[SerializeField] private bool shouldShakeCamera = false;
	[Range(0f,10.0f)] [SerializeField] private float shakeDuration;
	[Range(0f,10.0f)] [SerializeField] private float shakeStrength;

	[SerializeField] private ParticleSystem destructionEffect;

	[SerializeField] private float health;

	private void Start() {

	}

	public float GetHealth() {
		return health;
	}

	public void DecreaseHealth(float damage) {
		health -= damage;

		OnDamaged?.Invoke(this, new OnDamagedEventArgs { Health = health });
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (!TryGetComponent(out DamageDealer damageDealer)) return;

		DecreaseHealth(damageDealer.Damage);

		if (IsDead()) {
			OnKilled?.Invoke(this, EventArgs.Empty);

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
