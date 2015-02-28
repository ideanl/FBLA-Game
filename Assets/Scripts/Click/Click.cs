using UnityEngine;
using System.Collections;

public abstract class Click : MonoBehaviour {

	//Performs the action specific to the child class on click of the object.
	protected abstract void ClickAction();

	// Update is called once per frame
	protected virtual void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				//Based on the name of the object, call ClickAction() in that class.
				(hit.transform.GetComponent(hit.transform.name) as Click).ClickAction ();
			}
		}
	}
}
