using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzleChecker : MonoBehaviour {

	public Puzzle puzzle;
	public static bool passed = true;

	public void ValidateAnswer() {
		foreach (Transform sibling in transform.parent) {
			Button b = sibling.GetComponent<Button> ();
			b.interactable = false;

			if (sibling.name == "Correct") {
				ColorBlock cb = b.colors;
				cb.disabledColor = Color.green;
				b.colors = cb;
			}
		}

		if (transform.name != "Correct") {
			passed = false;
			Button b = GetComponent<Button> ();
			ColorBlock cb = b.colors;
			cb.disabledColor = Color.red;
			b.colors = cb;
		}
		transform.parent.parent.Find ("Continue").gameObject.SetActive (true);
	}

	public void Continue() {
		puzzle.Continue (passed);
		passed = true;
	}
}
