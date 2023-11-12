using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewGameHandler : MonoBehaviour {

	[SerializeField] private ScoreKeeper scoreKeeper;
	[SerializeField] private UIManager uIManager;
	[SerializeField] private GameObject player;

	void Start() {
		AddSubscribers();
		InitializePlayer();
	}

	void Update() {

	}

	private void AddSubscribers() {
		scoreKeeper.OnScoreUpdated += uIManager.HandleOnScoreUpdate;
	}

	private void UnsubscribeSubscribers() {
		scoreKeeper.OnScoreUpdated -= uIManager.HandleOnScoreUpdate;
	}

	private void InitializePlayer() {
		uIManager.SetHealthSliderMax(player.GetComponent<Health>().GetHealth());
		player.GetComponent<Health>().OnDamaged += uIManager.HandleOnHealthUpdate;
		//Get the player's health script, and then have the UIManager subscribe to that health here then?
	}

	private void DestroyPlayer() {
		player.GetComponent<Health>().OnDamaged -= uIManager.HandleOnHealthUpdate;
		//For resetting and also unsubscribing to things.
		//Might want to rethink renaming this to something like "restart game" later.
	}
}
