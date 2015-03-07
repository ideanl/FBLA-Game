using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : Click {

	public float OPEN_SPEED = 0.5f;

	public bool open = false;

	private Vector3 openPosition;
	private Vector3 closedPosition;
	private Vector3 openVelocity = Vector3.zero;

	public GameObject key;

	//Called before the first frame
	protected override void Awake() {
		base.Awake ();

		closedPosition = transform.position;
		Bounds bounds = transform.gameObject.renderer.bounds;
		float width = Vector3.Project(bounds.max - bounds.min, transform.right).magnitude;
		openPosition = transform.position - transform.right * width;
	}
		
	//Called once per frame
	void Update() {
		transform.rigidbody.isKinematic = open;
		transform.position = Vector3.SmoothDamp (transform.position, open ? openPosition : closedPosition, ref openVelocity, OPEN_SPEED);
	}

	//Open/Close the door
	public override void ClickAction() {
		if (transform.name != "Door") {
			List<GameObject> items = player.GetComponent<CustomCharacter> ().items;
			for (int i = 0; i < items.Count; i++) {
				if (items [i] == key) {
					open = !open;
				}
			}
		} else {
			open = !open;
		}
	}
}
