using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject disk;
	public GameObject spawnDisk;
	public float originalTimer = 0.3f;
	public float waitTimer = 0.3f;

	private const float FORWARD_FORCE = 1000;
	private const float UP_FORCE = 10;

	//Called once per frame
	void Update() {
		if (transform.parent && transform.parent.tag == "Player") {
			if (transform.parent.GetComponent<CustomCharacter> ().gunUp && Input.GetMouseButton (0) && waitTimer <= 0) {
				if (disk) {	
					Fire ();
					waitTimer = originalTimer;
				}
			}
		}
		waitTimer -= Time.deltaTime;
	}

	//Fires a disc
	public void Fire() {
		GameObject diskInstance = (GameObject)Instantiate (disk, spawnDisk.transform.position, spawnDisk.transform.rotation);
		diskInstance.rigidbody.AddForce (spawnDisk.transform.forward * FORWARD_FORCE + spawnDisk.transform.up * UP_FORCE);
	}
}