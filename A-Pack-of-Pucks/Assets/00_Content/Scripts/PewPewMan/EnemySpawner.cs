using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] private WaveConfigSO currentWave;

	public WaveConfigSO CurrentWave { get { return currentWave; } }

	void Start() {
		SpawnEnemies();
	}

	private void SpawnEnemies() {
		for (int i = 0; i < currentWave.GetEnemyCount(); i++) {
			Instantiate(currentWave.GetEnemy(i),
				currentWave.GetFirstWayPoint().position,
				Quaternion.identity,
				transform);
		}
	}
}
