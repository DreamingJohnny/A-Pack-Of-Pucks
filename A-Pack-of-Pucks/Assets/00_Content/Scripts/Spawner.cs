using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	//The gameobject to be spawned
	[SerializeField] private GameObject toSpawn;
	
	//The timespan inbetween each spawn
	[SerializeField] private float spawnSpan;
	//The time since an object was last spawned
	private float timeSinceSpawn;

	void OnEnabled() {
		timeSinceSpawn = 0f;
	}

	void Update() {

		if(timeSinceSpawn <= spawnSpan) {
			timeSinceSpawn += Time.deltaTime;
		}
		else {
			timeSinceSpawn = 0f;
			Instantiate(toSpawn, transform.position, transform.rotation);
		}
	}
}
