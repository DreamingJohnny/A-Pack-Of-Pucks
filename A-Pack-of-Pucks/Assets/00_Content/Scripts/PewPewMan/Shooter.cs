using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	//The gameobject that will be spawned on fire
	[SerializeField] private GameObject projectile;

	//Time inbetween each shot that's fired
	[SerializeField] private float rateOfFire;

	//is set by argument sent into the method, dictates if the weapon should continously fire
	private bool isFiringContinously;

	//Where the shots will be spawned from
	private List<Transform> cannonNozzles;

	private Coroutine firingCoroutine;


	void Start() {

	}
	private void OnEnable() {
		InitCannons();
	}

	private void InitCannons() {

		Transform[] transforms = GetComponentsInChildren<Transform>();
		cannonNozzles = new List<Transform>();

		//Ensures the list doesn't include the transform on this gameObject
		foreach (Transform transform in transforms) {
			if (transform != gameObject.transform) {
				cannonNozzles.Add(transform);
			}
		}
	}

	public void Fire(bool value) {
		isFiringContinously = value;

		if(isFiringContinously && firingCoroutine == null) {
			firingCoroutine = StartCoroutine(FireShots());
		}
		else if (!isFiringContinously && firingCoroutine != null) {
			StopCoroutine(firingCoroutine);
			firingCoroutine = null;
		}

	}

	private IEnumerator FireShots() {

		do {
			foreach (Transform transform in cannonNozzles) {
				Instantiate(projectile,
							transform.position,
							Quaternion.identity);
			}
			yield return new WaitForSeconds(rateOfFire);
		
		} while (isFiringContinously);
	}
}