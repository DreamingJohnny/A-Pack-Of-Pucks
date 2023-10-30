using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour {

	public static CinemachineShake Instance { get; private set; }

	private float shakeForce;
	private float shakeDuration;
	private float timeShaken = 0f;

	private CinemachineVirtualCamera cinemachineVirtualCamera;

	private void Awake() {
		Instance = this;
		cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
	}

	public void ShakeCamera(float intensity, float time) {
		CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

		cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
		shakeForce = intensity;
		shakeDuration = time;
		timeShaken = time;
	}

	private void Update() {
		if(timeShaken > 0) {
			timeShaken -= Time.deltaTime;
				CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

				cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(shakeForce,0f,timeShaken/shakeDuration);
		}
	}
}
