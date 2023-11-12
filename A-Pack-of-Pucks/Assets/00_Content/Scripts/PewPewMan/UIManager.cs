using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI scoreValue;
	[SerializeField] private Slider healthSlider;
	
	//might want to extend this to method for incase this hasn't been set.
	private float maxSliderHealth;

	public float MaxSliderHealth {
		get { if (maxSliderHealth <= 0f) 
				{
				Debug.Log($"{name} had a maxhealth value of zero or less. Hasn't the {name} received the players max health?");
				return healthSlider.maxValue;
			}
			else {
				return maxSliderHealth;
			}
		}
	}


	//So, should subscribe to events then, so need public methods for those events to subscribe to.
	void Start() {

	}


	void Update() {

	}

	public void SetHealthSliderMax(float tempMaxHealth) {
		maxSliderHealth = tempMaxHealth;
	}

	public void HandleOnScoreUpdate(object sender, ScoreKeeper.OnScoreUpdatedEventArgs e) {
		int i = Mathf.CeilToInt(e.Score);
		
		scoreValue.text = i.ToString();
	}

	public void HandleOnHealthUpdate(float health) {
		healthSlider.value = health / MaxSliderHealth;
	}
}