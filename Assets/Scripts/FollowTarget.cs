using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Class for following any target
public class FollowTarget : MonoBehaviour {

	public Transform target;
	public bool moves = false;
	public float startHealth = 100;
	public float currentHealth;
	public int currLevel = 0;
	public bool active = false;

	private GameObject enemyInfo;
	private GameObject enemyHealth;
	private Transform spawn;
	private bool autoFind = true;
	private float moveSpeed = 0.2f;
	private float turnSpeed = 4f;
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
			active = true;
			distance = Vector3.Distance (spawn.position, hit.collider.transform.position);
			GetComponent<Gun> ().Fire ();
		} else if (active && hit.collider && distance > Vector3.Distance (spawn.position, hit.collider.transform.position)) {
			transform.position = Vector3.Lerp (transform.position, transform.position - (target.position - transform.position), deltaTime * moveSpeed);
		} else if (active && hit.collider && distance < Vector3.Distance (spawn.position, hit.collider.transform.position)) {
			transform.position = Vector3.Lerp (transform.position, target.position, deltaTime * moveSpeed);
		}

	}

	// Use this for initialization
	void Start () {
		currentHealth = startHealth;
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
		if (currentHealth <= 0) {
			GameObject.Find ("Boss Portal").transform.Find ("Plane").renderer.enabled = true;
			Destroy (gameObject);
			Destroy (enemyInfo);
			GameObject.Find("GameControl").GetComponent<GameControl>().currLevel = Application.loadedLevel + 1;
		}
		enemyHealth.GetComponent<Slider>().value = currentHealth / 100;
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
