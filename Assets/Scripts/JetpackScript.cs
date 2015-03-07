using UnityEngine;
using System.Collections;

public class JetpackScript : MonoBehaviour {
	public static float FLOAT_SPEED = 0.3f;
	public static float MAX_TIME = 5;

	private float currTime = 0;
	private bool canFly = true;

	public void FlyJetpack(GameObject player) {
		if (canFly) {
			player.GetComponent<CharacterController> ().Move (player.transform.up * FLOAT_SPEED);
		}
	}

	void Update() {
		currTime += Time.deltaTime;
		if (currTime > MAX_TIME * 2) {
			canFly = true;
			currTime = 0;
		} else if (currTime > MAX_TIME) {
			canFly = false;
		}
	}

	public void StopJetpack(GameObject player) {
		player.GetComponent<CharacterController> ().SimpleMove (Vector3.zero);
	}
}
