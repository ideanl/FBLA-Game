using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pickup : Click {

	protected override void Awake() {
		base.Awake ();
	}

	public override void ClickAction() {
		player.GetComponent<CustomCharacter> ().items.Add(transform.gameObject);
		transform.parent = GameObject.Find("GameControl").transform;
		transform.gameObject.SetActive (false);

		if (transform.name == "Jetpack") {
			GameObject messaging = GameObject.Find ("Messaging").gameObject;

			if (messaging) {
				messaging.GetComponent<Canvas> ().enabled = true;
				messaging.transform.Find ("MessagingBox").Find ("Text").GetComponent<Text> ().text = "You just found a jetpack! Press 2 to use this item.\n\nPress Enter to Continue";
			}
		}
	}
}
