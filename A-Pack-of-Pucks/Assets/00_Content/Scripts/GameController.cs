using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	[SerializeField] UIHandler uiHandler;
	//TODO: Turn this into a singleton
	//TODO: This sends the points on to the UI Handler then

	void Start() {
		SetUpPoints();
	}

	private void SetUpPoints() {

		Point[] points = FindObjectsOfType<Point>();

		foreach (Point point in points) {
			point.OnPointCollect.AddListener(IncreaseScore);
		}

	}

	private void IncreaseScore() {
		if(uiHandler != null) {
			uiHandler.UpdateScore();
		}
	}

	void Update() {

	}
}
