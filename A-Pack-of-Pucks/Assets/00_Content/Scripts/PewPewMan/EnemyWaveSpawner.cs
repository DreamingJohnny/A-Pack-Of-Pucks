using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour {

	[SerializeField] private ScoreKeeper scoreKeeper;

	//public static EnemyWaveSpawner Instance;

	[SerializeField] private bool isLoopingWaves;

	[SerializeField] private List<WaveConfigSO> waveConfigSOs;
	private int currentWaveIndex = 0;

	public WaveConfigSO CurrentWave { get { return waveConfigSOs[currentWaveIndex]; } }

	private void Awake() {
		//Instance = this;
	}

	void Start() {
		StartCoroutine(SpawnEnemyWaves());
	}

	private IEnumerator SpawnEnemyWaves() {

		do {
			for (currentWaveIndex = 0; currentWaveIndex < waveConfigSOs.Count; currentWaveIndex++) {

				for (int i = 0; i < CurrentWave.GetEnemyCount(); i++) {
					GameObject tempEnemy = Instantiate(	CurrentWave.GetEnemy(i),
														CurrentWave.GetFirstWayPoint().position,
														Quaternion.identity,
														transform);


					//On dead should ideally send with it an enum or something so that I can look at the type of enemy it is that dies
					tempEnemy.GetComponent<Health>().OnKilled += scoreKeeper.HandleOnKilled;

					yield return new WaitForSeconds(CurrentWave.GetSpanBetweenSpawn);
				}

				yield return new WaitForSeconds(CurrentWave.PauseAtEndOfWave);
			}
		} while (isLoopingWaves);
	}
}
