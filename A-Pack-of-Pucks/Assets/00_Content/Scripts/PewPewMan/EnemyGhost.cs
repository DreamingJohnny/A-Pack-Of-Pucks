using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyGhost : MonoBehaviour {

	[SerializeField] private EnemyType enemyType;

	public EnemyType EnemyType { get { return enemyType; } }

	private Shooter shooter;
	[SerializeField] private float reloadTime;
	private float timeSinceShot;

	[SerializeField] private float speed;

	public float Speed { get { return speed; } }

	private void OnEnable() {
		timeSinceShot = 0f;

		shooter = GetComponent<Shooter>();
	}

	void Update() {
		Shoot();
	}

	private void Shoot() {
		if (reloadTime <= timeSinceShot) {
			timeSinceShot = 0f;
			shooter.Fire(true);
		}
		else {
			timeSinceShot += Time.deltaTime;
		}
	}
}