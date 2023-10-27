using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour {

	[SerializeField] private bool isLoopingWaves;

	[SerializeField] private List<WaveConfigSO> waveConfigSOs;
	private int currentWaveIndex = 0;

	public WaveConfigSO CurrentWave { get { return waveConfigSOs[currentWaveIndex]; } }

	void Start() {
		StartCoroutine(SpawnEnemyWaves());
	}

	private IEnumerator SpawnEnemyWaves() {

		do {
			for (currentWaveIndex = 0; currentWaveIndex < waveConfigSOs.Count; currentWaveIndex++) {

				for (int i = 0; i < CurrentWave.GetEnemyCount(); i++) {
					Instantiate(CurrentWave.GetEnemy(i),
						CurrentWave.GetFirstWayPoint().position,
						Quaternion.identity,
						transform);

					yield return new WaitForSeconds(CurrentWave.GetSpanBetweenSpawn);
				}

				yield return new WaitForSeconds(CurrentWave.PauseAtEndOfWave);
			}
		} while (isLoopingWaves);
	}
}
