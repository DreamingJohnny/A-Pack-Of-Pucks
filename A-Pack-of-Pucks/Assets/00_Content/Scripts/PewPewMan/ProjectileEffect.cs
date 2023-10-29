using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEffect : MonoBehaviour
{
	[SerializeField] private ParticleSystem InstantiatedEffect;
	[SerializeField] private ParticleSystem DestroyedEffect;

	//Rethink if all of this should be a singleton handling all of these effects, one that recieves positions and types maybe?

	//TODO: Rename this, it is very confusing name
	public void PlayStartingEffect() {

		ParticleSystem instance = Instantiate(InstantiatedEffect, transform.position, Quaternion.identity);
		Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
	}

	public void PlayDestructionEffect() {
		ParticleSystem instance = Instantiate(DestroyedEffect, transform.position, Quaternion.identity);
		Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
	}
}
