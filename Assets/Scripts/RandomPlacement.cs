using UnityEngine;
using System.Collections;

public class RandomPlacement : MonoBehaviour {
	public float RADIUS = 5;
	public int numberOfItems = 6;

	public GameObject[] items;

	void Start() {
		foreach (GameObject item in items) {
			GameObject piece = (GameObject) Instantiate(item, transform.position, transform.rotation);
			piece.transform.parent = transform;

			float x = Random.Range (0, RADIUS);
			float z = Random.Range (0, Mathf.Sqrt(Mathf.Pow (RADIUS, 2) - Mathf.Pow (x, 2)));

			transform.localPosition = new Vector3 (x, transform.localPosition.y, z);

			transform.rotation = Random.rotation;
		}
	}
}
