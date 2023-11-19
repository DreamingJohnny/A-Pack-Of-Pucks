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
		//To ensure the healthSlider has the current health of the player
		player.GetComponent<Health>().DecreaseHealth(0f);

	}

	private void DestroyPlayer() {
		player.GetComponent<Health>().OnDamaged -= uIManager.HandleOnHealthUpdate;
		//For resetting and also unsubscribing to things.
		//Might want to rethink renaming this to something like "restart game" later.
	}
}
