using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject disk;
	public GameObject spawnDisk;
	public float originalTimer = 0.2f;
	public float waitTimer = 0.2f;

	private const float FORWARD_FORCE = 1000;
	private const float UP_FORCE = 10;

	//Called once per frame
	void Update() {
		if (transform.parent && transform.parent.tag == "Player") {
			if (transform.parent.GetComponent<CustomCharacter> ().gunUp && Input.GetMouseButton (0)) {
				if (disk) {	
					Fire ();
				}
			}
		}
	}

	//Fires a disc
	public void Fire() {
		if (waitTimer <= 0) {
			GameObject diskInstance = (GameObject)Instantiate (disk, spawnDisk.transform.position, spawnDisk.transform.rotation);
			diskInstance.GetComponent<Disc> ().origin = spawnDisk;
			diskInstance.rigidbody.AddForce (spawnDisk.transform.forward * FORWARD_FORCE + spawnDisk.transform.up * UP_FORCE);
			waitTimer = originalTimer;
		}
		waitTimer -= Time.deltaTime;
	}
}