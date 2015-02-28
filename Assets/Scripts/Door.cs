using UnityEngine;
using System.Collections;

public class Door : Click {

	public float OPEN_SPEED = 0.5f;

	public bool open = false;

	private Vector3 openPosition;
	private Vector3 closedPosition;
	private Vector3 openVelocity = Vector3.zero;

	//Called before the first frame
	void Awake() {
		closedPosition = transform.position;
		Bounds bounds = transform.gameObject.renderer.bounds;
		float width = Vector3.Project(bounds.max - bounds.min, transform.right).magnitude;
		openPosition = transform.position - transform.right * width;
	}
		
	//Called once per frame
	protected override void Update() {
		base.Update();

		transform.position = Vector3.SmoothDamp (transform.position, open ? openPosition : closedPosition, ref openVelocity, OPEN_SPEED);
	}

	//Open/Close the door
	protected override void ClickAction() {
		open = !open;
	}
}
