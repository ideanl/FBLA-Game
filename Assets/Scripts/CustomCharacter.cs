using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomCharacter : MonoBehaviour {

	public float BOB_AMOUNT_Y = 0.1f;
	public float BOB_SPEED = 0.1f;
	public float BOB_AMOUNT_X = 0.2f;
	public float SPRINT_CONSTANT = 2f;
	public float HEIGHT_RATIO = 0.9f;

	public GameObject jetpack;

	public bool gunUp = false;
	public List<GameObject> items = new List<GameObject>(4);

	private Vector3 gunUpPosition = new Vector3(1.651169f, -0.2296759f, 0.1973185f);
	private Vector3 gunDownPosition = new Vector3 (0.151332f, -1.2949999f, 0.92f);
	private Vector3 rotationUp = new Vector3 (0, 0, 0);
	private Vector3 rotationDown = new Vector3 (51.64737f, 303.8983f, 349.0694f);

	private Vector3 gunMoveVelocity = Vector3.zero;

	private Vector3 lastPosition;
	private float stepCounter = 0;
	private float startX;
	private float startY;

	private Transform weapon;
	private new Transform camera;

	//Called initially
	void Awake() {		
		camera = Camera.main.transform;
		startX = transform.position.x;
		startY = transform.position.y;
		lastPosition = camera.position;
		weapon = GameObject.FindGameObjectWithTag ("Weapon").transform;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			PutGunUp ();
		}

		if (items [0] == jetpack) {
			if (Input.GetKey (KeyCode.Alpha2)) {
				jetpack.GetComponent<JetpackScript> ().FlyJetpack (this.gameObject);
			} else if (Input.GetKeyUp (KeyCode.Alpha2)) {
				jetpack.GetComponent<JetpackScript> ().StopJetpack (this.gameObject);
			}
		}

		PositionGun ();

		if (!camera.GetComponent<MouseLook> ().aimingTrue && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))) {
			//BobPlayer ();
		}
	}


	//Sets variables for the gun being up
	void PutGunUp() {
		camera.GetComponent<MouseLook> ().aimingTrue = false;
		gunUp = !gunUp;
	}

	//Positions and Rotates the gun based on gunUp value.
	void PositionGun() {
		weapon.localPosition = Vector3.SmoothDamp (weapon.localPosition, camera.localPosition - (gunUp ? gunUpPosition : gunDownPosition), ref gunMoveVelocity, 0.1f);

		if (gunUp && Vector3.Distance (weapon.localPosition, camera.localPosition - gunUpPosition) < 0.1) {
			weapon.localEulerAngles = rotationUp;
		} else if (!gunUp) {
			weapon.localEulerAngles = rotationDown;
		}
	}

	//Player bobbing in the x and y direction on movement using sine function.
	void BobPlayer() {
		float bobSpeed = Input.GetKey (KeyCode.LeftShift) ? BOB_SPEED * SPRINT_CONSTANT : BOB_SPEED;
		float distance = Vector3.Distance(lastPosition, transform.position) * bobSpeed;
		stepCounter += distance;

		float x = Mathf.Sin (stepCounter) * BOB_AMOUNT_X + startX;
		float y = (Mathf.Sin (stepCounter * 2) * BOB_AMOUNT_Y * -1) + startY;

		transform.position = new Vector3 (x, y, transform.position.z);
		lastPosition = transform.position;

		Vector3 weaponDistance = camera.localPosition - weapon.localPosition;
	}
}