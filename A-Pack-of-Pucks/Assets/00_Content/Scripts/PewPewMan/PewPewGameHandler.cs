using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewGameHandler : MonoBehaviour {

	[SerializeField] private ScoreKeeper scoreKeeper;
	[SerializeField] private UIManager uIManager;

	void Start() {
		AddSubscribers();
	}

	void Update() {

	}

	private void AddSubscribers() {
		scoreKeeper.OnScoreUpdated += uIManager.HandleOnScoreUpdate;
	}

	private void UnsubscribeSubscribers() {
		scoreKeeper.OnScoreUpdated -= uIManager.HandleOnScoreUpdate;
	}
	//So, a function where it gets and handles the subscriptions?
	//So, the uIManager needs to get the scoreKeeper?
}
