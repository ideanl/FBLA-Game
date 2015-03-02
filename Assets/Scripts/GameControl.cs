using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public float health;

	// Use this for initialization
	void Awake () {
		if (!control) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else {
			Destroy (gameObject);
		}
	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 100, 30), "Health: " + health);
	}
}
