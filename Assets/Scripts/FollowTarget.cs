using UnityEngine;
using System.Collections;

//Class for following any target
public class FollowTarget : MonoBehaviour {

	public Transform target;
	public bool moves = false;

	private bool autoFind = true;
	private float moveSpeed = 0.2f;
	private float turnSpeed = 2.5f;
	private float distance;

	void Follow (float deltaTime) {
		if (moves)
			transform.position = Vector3.Lerp (transform.position, target.position, deltaTime * moveSpeed);

		Vector3 targetDir = target.position - transform.position;
		targetDir.y = 0;

		targetDir = Vector3.Cross (targetDir, new Vector3 (0, -1, 0));

		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, deltaTime * turnSpeed, 0);
		transform.rotation = Quaternion.LookRotation (newDir);

		Transform spawn = transform.Find ("SpawnDisk");

		RaycastHit hit;
		if (Physics.Raycast (spawn.position, spawn.forward, out hit) && hit.collider.gameObject.tag == "Player") {
			distance = Vector3.Distance (spawn.position, hit.collider.transform.position);
			GetComponent<Gun> ().Fire ();
		} else if (distance > Vector3.Distance (spawn.position, hit.collider.transform.position)) {
			transform.position = Vector3.Lerp (transform.position, target.position, - deltaTime * moveSpeed);
		} else if (distance < Vector3.Distance (spawn.position, hit.collider.transform.position)) {
			transform.position = Vector3.Lerp (transform.position, target.position, deltaTime * moveSpeed);
		}
	}

	// Use this for initialization
	void Start () {
		if (autoFind) {
			FindTarget ();
		}
	} // end of Start()
	
	// FixedUpdate is called before a physics update
	void FixedUpdate () {
		if (autoFind && (target == null || !target.gameObject.activeSelf)) {
			FindTarget ();
		}
			
		if (target != null) {
			Follow (Time.deltaTime);
		}
	} // end of FixedUpdate()

	// Find the target
	void FindTarget() {
		if (target == null) {
			GameObject targetObj = GameObject.FindGameObjectWithTag ("Player");
			if (targetObj) {
				target = targetObj.transform;
			}
		}
	} // end of findTarget()
}
