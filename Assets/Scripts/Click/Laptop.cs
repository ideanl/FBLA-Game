using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Laptop : Click {

	public Transform targetCharacter;
	public Transform targetObject;
	private bool isForDoor = false;
	private bool isForFort = false;
	private bool isForBoss = false;
	public bool isClicked = false;
	public float MAX_DISTANCE = 0;
	// Use this for initialization
	protected override void Awake() {
		base.Awake ();
		FindTarget ();
		if (targetObject.tag == "Door") {
			isForDoor = true;
		} else if (targetObject.tag == "Enemy") {
			isForBoss = true;
		} else {
			isForFort = true;
		}
	}

	float findDistance() {
		return Vector3.Distance (targetCharacter.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		float distance = findDistance ();
		if (isClicked) {
			if(isForDoor && distance <= MAX_DISTANCE) {
				targetObject.GetComponent<Door>().open = true;
			} else if (isForBoss && distance <= MAX_DISTANCE) {

			} else if (isForFort && distance <= MAX_DISTANCE) {

			}
		}	
	}

	void FindTarget() {
		if (targetCharacter == null) {
			GameObject targetObj = GameObject.FindGameObjectWithTag ("Player");
			if (targetObj) {
				targetCharacter = targetObj.transform;
			}
		}
	}

	public override void ClickAction() {
			isClicked = true;
	}
}
