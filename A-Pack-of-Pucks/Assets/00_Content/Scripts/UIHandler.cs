using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour {

	private int score = 0;

	[SerializeField] private TextMeshProUGUI scoreDisplay;

	public void UpdateScore() {
		score++;

		scoreDisplay.text = score.ToString();
	}
}