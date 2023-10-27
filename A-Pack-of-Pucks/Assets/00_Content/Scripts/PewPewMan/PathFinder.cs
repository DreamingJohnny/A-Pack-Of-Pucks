using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour {

	private EnemyWaveSpawner enemySpawner;
	private WaveConfigSO wave;

	public float GetSpeed {
		get {
			if (TryGetComponent(out EnemyGhost enemyGhost)) {
				return enemyGhost.Speed;
			}
			else {
				Debug.Log($"{name} tried to get the speed variable from the EnemyGhost component on the same gameobject, but was unsuccessful, instead the speed was set to zero.");
				return 0f;
			}
		}
	}

	private int waypointIndex;

	private List<Transform> waypoints;

	private void OnEnable() {

		enemySpawner = FindObjectOfType<EnemyWaveSpawner>();

		wave = enemySpawner.CurrentWave;


		waypointIndex = 0;
		waypoints = wave.GetWayPoints();
		transform.position = waypoints[waypointIndex].position;
	}

	void Update() {
		if (waypointIndex < waypoints.Count) {
			if(transform.position == waypoints[waypointIndex].position) {
				waypointIndex++;
			}
			else {
				transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, (GetSpeed * Time.deltaTime));
			}
		}
		else {
			Destroy(gameObject);
		}
	}
}
