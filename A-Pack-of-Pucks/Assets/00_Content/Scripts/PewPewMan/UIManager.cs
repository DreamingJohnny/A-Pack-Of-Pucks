using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI scoreValue;
	[SerializeField] private Slider healthSlider;
	
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

	public void HandleOnHealthUpdate(object sender, Health.OnDamagedEventArgs e) {
		healthSlider.value = e.Health / MaxSliderHealth;
	}
}