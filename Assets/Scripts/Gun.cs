using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject disk;
	public GameObject spawnDisk;
	public float waitTimer = 1;

	void Update() {
		if (transform.parent.GetComponent<Movement>().gunUp && Input.GetMouseButton (0) && waitTimer <= 0) {
			if (disk) {	
				Fire ();
				waitTimer = 1;
			}
		}
		waitTimer -= Time.deltaTime;
	}

	void Fire() {
		GameObject diskInstance = (GameObject) Instantiate (disk, spawnDisk.transform.position, spawnDisk.transform.rotation);
		diskInstance.rigidbody.AddForce(transform.forward * 3000 + transform.up * 50);
	}
}