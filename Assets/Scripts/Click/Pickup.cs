using UnityEngine;
using System.Collections;

public class Pickup : Click {

	protected override void Awake() {
		base.Awake ();
	}

	public override void ClickAction() {
		player.GetComponent<CustomCharacter> ().items.Add(transform.gameObject);
		transform.parent = player.transform;
		transform.gameObject.SetActive (false);
	}
}
