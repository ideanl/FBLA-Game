using UnityEngine;
using System.Collections;

public class Pickup : Click {

	public GameObject player;

	void Awake() {
		player = GameObject.FindGameObjectsWithTag ("Player") [0];
	}

	public override void ClickAction() {
		if (Vector3.Distance (player.transform.position, transform.position) < 2) {
			player.GetComponent<CustomCharacter> ().items.Add(transform.gameObject);
			transform.parent = player.transform;
			transform.gameObject.renderer.enabled = false;
		}
	}
}
