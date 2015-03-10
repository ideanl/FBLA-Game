﻿using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour {
	public static float FLOAT_SPEED = 0.3f;
	public static float MAX_TIME = 3;

	private float currTime = 0;
	private bool canFly = true;
	private bool isUpgraded = false;

	public void FlyJetpack(GameObject player) {
		if (canFly) {
			player.GetComponent<CharacterController> ().Move (player.transform.up * FLOAT_SPEED);
		}
	}

	void Update() {
		currTime += Time.deltaTime;
		if (Application.loadedLevel > 4) {
			isUpgraded = true;
		} 
		if (Application.loadedLevel > 7) {
			MAX_TIME *= 2;
		}
		if (currTime > MAX_TIME * 2) {
			canFly = true;
			currTime = 0;
		} else if (currTime > MAX_TIME && !isUpgraded) {
			canFly = false;
		} else if (currTime > MAX_TIME * 2 && isUpgraded) {
			canFly = false;
		}
	}

	public void StopJetpack(GameObject player) {
		player.GetComponent<CharacterController> ().SimpleMove (Vector3.zero);
	}
}
