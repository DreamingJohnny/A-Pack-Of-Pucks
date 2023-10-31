using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float lifeTime;
	private float timeLived;

	[SerializeField] private ParticleSystem creationEffect;

	private void OnEnable() {
		timeLived = 0f;

		PlayCreationEffects();
	}

	private void PlayCreationEffects() {
		AudioPlayer.Instance.EnemyShooting();

		ParticleSystem instance = Instantiate(creationEffect, transform.position, Quaternion.identity);

		Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
	}

	private void Update() {
		Movement();

		CheckLifeTime();
	}

	private void Movement() {
		transform.position = Vector3.MoveTowards(transform.position,
												target: new Vector3(transform.position.x, transform.position.y - 1, transform.position.z),
												speed * Time.deltaTime);
	}

	/// <summary>
	/// Checks how long the projectile has been instantiated for, and destroys it when it's lived beyond lifeTime
	/// </summary>
	private void CheckLifeTime() {
		if (timeLived <= lifeTime) {
			timeLived += Time.deltaTime;
		}
		else {
			Destroy(gameObject);
		}
	}
}