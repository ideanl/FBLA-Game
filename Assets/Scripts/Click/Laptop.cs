	using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Laptop : Click {

	public Transform targetCharacter;
	public Transform targetObject;
	public Transform targetObject1 = null;
	public Transform targetObject2 = null;
	public Transform targetObject3 = null;
	public Transform targetObject4 = null;
	public Transform targetObject5 = null;
	public Transform targetObject6 = null;
	public Transform targetObject7 = null;
	private bool isForDoor = false;
	private bool isForFort1 = false;
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
			isForFort1 = true;
		}

		if (targetObject1) {
			if (targetObject1.tag == "Fort") {
				isForFort = true;
			}
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
				targetObject.GetComponent<FollowTarget>().currentHealth -= targetObject.GetComponent<FollowTarget>().startHealth / 3;
				Destroy (gameObject);
			} else if (isForFort1 && distance <= MAX_DISTANCE) {
				targetObject.GetComponent<turret>().isFiring = false;
			} else if (isForFort && distance <=MAX_DISTANCE) {
				targetObject1.GetComponent<turret>().isFiring = false;
				targetObject2.GetComponent<turret>().isFiring = false;
				targetObject3.GetComponent<turret>().isFiring = false;
				targetObject4.GetComponent<turret>().isFiring = false;
				targetObject5.GetComponent<turret>().isFiring = false;
				targetObject6.GetComponent<turret>().isFiring = false;
				targetObject7.GetComponent<turret>().isFiring = false;
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
