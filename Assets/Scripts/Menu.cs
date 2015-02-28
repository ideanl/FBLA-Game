using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {
	Text txt;
	private int frames = 0;

	const string message = "WELCOME TO SAI!";

	void Start() {
		txt = gameObject.GetComponent<Text>();
		txt.text = "";
	}

	void Update() {
		if (frames % 7 == 0) {
			addToWelcome ();
		}
		frames++;
	}

	private void addToWelcome() {
		txt.text += message [txt.text.Length];

		if (txt.text.Length == message.Length) {
			txt.text = "";
			frames = 0;
		}
	}
}
