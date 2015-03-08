using UnityEngine;
using System.Collections;

//PORTAL REQUIRES: RIGIDBODY(NO GRAVITY) AND COLLIDER(IS TRIGGER = TRUE)
public class Portal : MonoBehaviour {

	public Transform matchingPortal;

	public int levelNumber = -1;

	//Upon instantiation, find the matching portal.
	void Awake() {
		if (levelNumber == -1) {
			foreach (Transform child in transform.parent) {
				if (child.gameObject.GetInstanceID () != this.gameObject.GetInstanceID ()) {
					matchingPortal = child;
				}
			}
		}
	}

	// When something intersects the portal.
	void OnTriggerEnter (Collider collider) {
		//If it's a player make it pop out of the matching portal.
		if (collider.gameObject.tag == "Player") {
			if (matchingPortal) {
				Transform player = collider.gameObject.transform;
				player.position = matchingPortal.transform.position;
				player.rotation = matchingPortal.transform.rotation;
				Bounds bounds = transform.gameObject.renderer.bounds;
				float width = Vector3.Project (bounds.max - bounds.min, player.forward).magnitude;
				player.position += player.forward * width;
			} else if (levelNumber > 0) {
				Application.LoadLevel (levelNumber);
			}
		}
	}
}
