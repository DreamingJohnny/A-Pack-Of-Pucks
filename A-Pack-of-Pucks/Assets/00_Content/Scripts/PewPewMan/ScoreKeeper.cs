using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	[Min(0)] private float score;

	public float Score { get { return score; } }

	private void Start() {
	}

	public void HandleOnKilled(object sender, EventArgs e) {

		Health health = (Health)sender;

		health.gameObject.TryGetComponent<EnemyGhost>(out EnemyGhost enemy);

		Debug.Log($"{enemy.EnemyType} was spawned by the enemy spawner and has now died.");

		health.OnKilled -= HandleOnKilled;
	}

	public void AddScore(float value) {
		score += value;
	}

	public void ResetScore() {
		score = 0f;
	}

}
