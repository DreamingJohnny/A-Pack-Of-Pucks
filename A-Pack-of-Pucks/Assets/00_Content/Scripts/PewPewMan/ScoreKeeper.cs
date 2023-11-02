using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	[Min(0)] private float score;

	public float Score { get { return score; } }

	[Header("Score list")]
	[SerializeField] private float basicEnemyPurple_Score;
	[SerializeField] private float basicEnemyRed_Score;
	[SerializeField] private float BossEnemyBlue_Score;

	private void Start() {
	}

	public void HandleOnKilled(object sender, EventArgs e) {

		Health health = (Health)sender;

		health.gameObject.TryGetComponent<EnemyGhost>(out EnemyGhost enemy);

		AddScoreOnEnemyType(enemy.EnemyType);

		health.OnKilled -= HandleOnKilled;
	}

	private void AddScoreOnEnemyType(EnemyType enemyType) {

		switch (enemyType) {
			case EnemyType.NotAnEnemy:
				break;
			case EnemyType.BasicEnemy_Purple:
				AddScore(basicEnemyPurple_Score);
				break;
			case EnemyType.BasicEnemy_Red:
				AddScore(basicEnemyRed_Score);
				break;
			case EnemyType.Boss:
				break;
			default:
				break;
		}
	}

	public void AddScore(float value) {
		score += value;
		Debug.Log($"the score is now {score}.");
	}

	public void ResetScore() {
		score = 0f;
	}
}
