using UnityEngine;
using System.Collections;

public class Pickup : Click {

	public Transform player;

	void Awake() {
		player = GameObject.FindGameObjectsWithTag ("Player")[0].transform;
	}

	protected override void ClickAction() {
		if (Vector3.Distance (player.position, transform.position) < 2) {
			player.GetComponent<CustomCharacter> ().items.Add(transform.gameObject);
			transform.parent = player.transform;
			transform.gameObject.renderer.enabled = false;
		}
	}

	protected override void Update() {
		base.Update ();
	}
}
