using UnityEngine;
using System.Collections;

public class Pickup : Click {

<<<<<<< HEAD
	public Transform player;

	void Awake() {
		player = GameObject.FindGameObjectsWithTag ("Player")[0].transform;
	}

	protected override void ClickAction() {
		if (Vector3.Distance (player.position, transform.position) < 2) {
=======
	public GameObject player;

	void Awake() {
		player = GameObject.FindGameObjectsWithTag ("Player") [0];
	}

	public override void ClickAction() {
		if (Vector3.Distance (player.transform.position, transform.position) < 2) {
>>>>>>> origin/master
			player.GetComponent<CustomCharacter> ().items.Add(transform.gameObject);
			transform.parent = player.transform;
			transform.gameObject.renderer.enabled = false;
		}
	}
<<<<<<< HEAD

	protected override void Update() {
		base.Update ();
	}
=======
>>>>>>> origin/master
}
