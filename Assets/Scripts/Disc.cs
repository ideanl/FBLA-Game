using UnityEngine;
using System.Collections;

public class Disc : MonoBehaviour {

	public GameObject bulletMark;
	public float inFront = 0.001f;
	public GameObject origin;

	private Vector3 position;
	private Quaternion rotation;
	private GameObject control;

	void Awake() {
		control = GameObject.Find ("GameControl");
	}

	void Update() {
		RaycastHit hit;

		if (Physics.Raycast (origin.transform.position, (transform.position - origin.transform.position).normalized, out hit)
		    && Vector3.Distance (transform.position, origin.transform.position) - Vector3.Distance (origin.transform.position, hit.collider.transform.position) <= 1) {
			if (hit.collider.gameObject.tag == "Player") {
				if (control) {
					control.GetComponent<GameControl> ().health -= 1;
					Destroy (transform.gameObject);
				}
			} 
		} else if (Physics.Raycast (origin.transform.position, transform.forward, out hit) && hit.collider.gameObject.tag == "Enemy") {
			hit.collider.gameObject.GetComponent<FollowTarget> ().currentHealth -= 5;
			Destroy (transform.gameObject);
		}

		if (transform.position.y <= 0) {
			Destroy (transform.gameObject);
		}
	}
}
