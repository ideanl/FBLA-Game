using UnityEngine;
using System.Collections;

public class Disc : MonoBehaviour {
	void onCollisionStart(Collision collision) {
		Destroy (this);
	}
}
