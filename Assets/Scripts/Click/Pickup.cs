using UnityEngine;
using System.Collections;

public class Pickup : Click {

	protected override void Awake() {
		base.Awake ();
	}

	public override void ClickAction() {
		if (Vector3.Distance (player.transform.position, transform.position) < 2) {
			player.GetComponent<CustomCharacter> ().items.Add(transform.gameObject);
			transform.parent = player.transform;
			transform.gameObject.renderer.enabled = false;
		}
	}
}
