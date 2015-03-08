using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Class for following any target
public class FollowTarget : MonoBehaviour {

	public Transform target;
	public bool moves = false;
	public float health = 100;

	private GameObject enemyInfo;
	private GameObject enemyHealth;
	private Transform spawn;
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

		 	RaycastHit hit;
		if (Physics.Raycast (spawn.position, spawn.forward, out hit) && hit.collider && hit.collider.gameObject.tag == "Player") {
			distance = Vector3.Distance (spawn.position, hit.collider.transform.position);
			GetComponent<Gun> ().Fire ();
		} else if (hit.collider && distance > Vector3.Distance (spawn.position, hit.collider.transform.position)) {
			transform.position = Vector3.Lerp (transform.position, transform.position - (target.position - transform.position), deltaTime * moveSpeed);
		} else if (hit.collider && distance < Vector3.Distance (spawn.position, hit.collider.transform.position)) {
			transform.position = Vector3.Lerp (transform.position, target.position, deltaTime * moveSpeed);
		}
		Debug.Log (hit.collider);
		if (Input.GetKey(KeyCode.Alpha7))
			GetComponent<Gun> ().Fire ();	

	}

	// Use this for initialization
	void Start () {
		if (autoFind) {
			FindTarget ();
		}

		enemyInfo = GameObject.Find ("EnemyInfo");
		if (enemyInfo) {
			enemyHealth = enemyInfo.transform.Find ("Enemy Health").Find ("EnemyHealthVal").gameObject;
		}
		spawn = transform.Find ("SpawnDisk");
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

	void Update() {
		if (health <= 0) {
			Destroy (gameObject);
			Destroy (enemyInfo);
		}
		enemyHealth.GetComponent<Slider>().value = health / 100;
	}

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
