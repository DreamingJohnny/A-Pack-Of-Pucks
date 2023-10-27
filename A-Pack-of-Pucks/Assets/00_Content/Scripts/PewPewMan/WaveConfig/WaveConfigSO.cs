using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave Config", menuName = "New Wave Config", order = 0)]
public class WaveConfigSO : ScriptableObject {

	[SerializeField] private List<GameObject> enemyPrefabs;
	[SerializeField] private Transform preFabWayPoints;

	[SerializeField] private float spanBetweenSpawn;
	[SerializeField] private float pauseAtEndOfWave;

	/// <summary>
	/// Time in s between enemy spawning
	/// </summary>
	public float GetSpanBetweenSpawn { get { return spanBetweenSpawn; } }

	/// <summary>
	/// Time in s between last enemy in wave spawning and the wave ending
	/// </summary>
	public float PauseAtEndOfWave { get { return pauseAtEndOfWave; } }

	/// <summary>
	/// Returns the gameobject at the given index within the list "enemyPrefabs".
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public GameObject GetEnemy(int index) {

		if(index > enemyPrefabs.Count) {
			Debug.Log($"{name} was just asked to give a enemy outside the bounds of it's list of enemies, the last enemy will be sent instead.");

			return enemyPrefabs[enemyPrefabs.Count];
		}
		else {
			return enemyPrefabs[index];
		}

	}
	/// <summary>
	/// Returns int equal to length of list "enemyPrefabs".
	/// </summary>
	/// <returns></returns>
	public int GetEnemyCount() {
		return enemyPrefabs.Count;
	}

	public Transform GetFirstWayPoint() {
		return preFabWayPoints.GetChild(0);
	}

	public List<Transform> GetWayPoints() {
		List<Transform> wayPoints = new List<Transform>();

		foreach (Transform wayPoint in preFabWayPoints) {
			wayPoints.Add(wayPoint);
		}

		return wayPoints;
	}
}
