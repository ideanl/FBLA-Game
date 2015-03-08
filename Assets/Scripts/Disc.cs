using UnityEngine;
using System.Collections;

public class Disc : MonoBehaviour {

	public GameObject bulletMark;
	public float inFront = 0.001f;

	private Vector3 position;
	private Quaternion rotation;

	void Update() {
		//RaycastHit hit;
		//if (Physics.Raycast (transform.position, transform.forward, out hit, 100)) {
		//	Instantiate (bulletMark, hit.point + (hit.normal * inFront), Quaternion.Euler(0, 0,0));
		//}
		if (transform.position.y <= 0) {
			Destroy (transform.gameObject);
		}
		//Destroy (transform.gameObject);
	}

	void onCollisionEnter(Collision collision) {
		Debug.Log ("HERE");
	}
}
