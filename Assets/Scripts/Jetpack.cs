using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour {
	public static float FLOAT_SPEED = 0.3f;
	public static float MAX_TIME = 5;

	private float currTime = 0;
	private bool canFly = true;
	private bool isUpgraded = false;
	GameObject targetObj = null;

	public void FlyJetpack(GameObject player) {
		if (canFly) {
			player.GetComponent<CharacterController> ().Move (player.transform.up * FLOAT_SPEED);
		}
	}

	void Start() {
		targetObj = GameObject.FindGameObjectWithTag ("Player");
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
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			FlyJetpack(targetObj);
		}
	}

	public void StopJetpack(GameObject player) {
		player.GetComponent<CharacterController> ().SimpleMove (Vector3.zero);
	}
}
