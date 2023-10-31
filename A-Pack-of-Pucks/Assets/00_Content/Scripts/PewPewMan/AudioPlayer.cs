using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

	public static AudioPlayer Instance { get; private set; }

	[SerializeField] [Range(0f,1f)] private float volume;
	
	[Header("Shooting Sounds")]
	[SerializeField] private AudioClip playerShootingClip;
	[SerializeField] private AudioClip enemyShootingClip;

	[Header("Explosion Sounds")]
	[SerializeField] private AudioClip playerExplodingClip;
	[SerializeField] private AudioClip enemyExplodingClip;

	private void Awake() {
		Instance = this;
	}

	public void PlayerShooting() {
		if(playerShootingClip != null) {
			AudioSource.PlayClipAtPoint(playerShootingClip, Camera.main.transform.position, volume);

		}
	}

	public void EnemyShooting() {
		if (enemyShootingClip != null) {
			AudioSource.PlayClipAtPoint(enemyShootingClip, Camera.main.transform.position, volume);

		}
	}

	public void PlayerExploding() {
		if (playerExplodingClip != null) {
			AudioSource.PlayClipAtPoint(playerExplodingClip, Camera.main.transform.position, volume);

		}
	}

	public void EnemyExploding() {
		if (enemyExplodingClip != null) {
			AudioSource.PlayClipAtPoint(enemyExplodingClip, Camera.main.transform.position, volume);

		}
	}
}
