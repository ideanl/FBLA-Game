using UnityEngine;
using System.Collections;

public class ClickController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectsWithTag ("Player") [0];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && player.GetComponent<CustomCharacter>().gunUp == false) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.GetComponent (hit.transform.tag)) {
					//Based on the name of the object, call ClickAction() in that class.
					(hit.transform.GetComponent (hit.transform.tag) as Click).ClickAction ();
				}
			}
		}
	}
}
