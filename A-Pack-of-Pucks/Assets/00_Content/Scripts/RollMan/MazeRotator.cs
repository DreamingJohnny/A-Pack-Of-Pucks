using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;
using static Unity.Mathematics.mathx;

public class MazeRotator : MonoBehaviour {

	[SerializeField] private Transform maze;
	[SerializeField] private float m_rotSpeed;

	private float m_rot;

	private float m_beginRot;
	private float m_beginTheta;

	private void Update() {
		Vector2 mazePos = maze.position;
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector2 localMousePos = mousePos - mazePos;

		float theta = Mathf.Atan2(localMousePos.y, localMousePos.x);

		if (Input.GetMouseButtonDown(0)) {
			m_beginTheta = theta;
			m_beginRot = m_rot;
		}
		if (Input.GetMouseButton(0)) {
			float delta = theta - m_beginTheta;
			float rotTarget = m_beginRot + delta;
			m_rot = RotateTowards(m_rot, rotTarget, m_rotSpeed * Mathf.Deg2Rad * Time.deltaTime);

			maze.rotation = Quaternion.Euler(0, 0, m_rot * Mathf.Rad2Deg);
		}
	}

	private static float RotateTowards(float current, float target, float maxTurn) {
		float diff = SignedRadialDist(current, target);
		float diffClamped = Mathf.Clamp(diff, -maxTurn, maxTurn);

		return WrapRot(current + diffClamped);
	}

	private static float SignedRadialDist(float current, float target) {
		float diff0 = target - current;
		float diff1 = (mathx.TAU - Mathf.Abs(diff0)) * Mathf.Sign(-diff0);
		float diffMin = Mathf.Abs(diff0) < Mathf.Abs(diff1) ? diff0 : diff1;

		return diffMin;
	}

	private static float WrapRot(float angle) =>
		mathx.mod(angle + Mathf.PI, mathx.TAU) - Mathf.PI;
}