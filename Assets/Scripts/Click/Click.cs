using UnityEngine;
using System.Collections;

public abstract class Click : MonoBehaviour {

	public GameObject player;

	protected virtual void Awake() {
		player = GameObject.FindGameObjectsWithTag ("Player") [0];
	}

	//Performs the action specific to the child class on click of the object.
	public abstract void ClickAction();
}
