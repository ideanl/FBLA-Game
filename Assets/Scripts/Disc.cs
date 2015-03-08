using UnityEngine;
using System.Collections;

public class Disc : MonoBehaviour {

	public GameObject bulletMark;
	public float inFront = 0.001f;

	private Vector3 position;
	private Quaternion rotation;
	private GameObject control;

	void Awake() {
		control = GameObject.Find ("GameControl");
	}

	void Update() {
		if (transform.position.y <= 0) {
			Destroy (transform.gameObject);
		}
	}

	void onTriggerEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			if (control) {
				control.GetComponent<GameControl> ().health -= 1;
			}
		} else if (collision.gameObject.tag == "Enemy") {
			collision.gameObject.GetComponent<FollowTarget> ().health -= 5;
		}
	}
}
