using UnityEngine;
using System.Collections;

//Abstract class for following any target
public abstract class FollowTarget : MonoBehaviour {

	public Transform target;
	private bool autoFind = true;

	protected abstract void Follow (float deltaTime);

	// Use this for initialization
	virtual protected void Start () {
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
	public void FindTarget() {
		if (target == null) {
			GameObject targetObj = GameObject.FindGameObjectWithTag ("Player");
			if (targetObj) {
				target = targetObj.transform;
			}
		}
	} // end of findTarget()
}
