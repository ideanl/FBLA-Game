using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour {
	public string question;
	public string[] choices = new string[4];
	public int answer;
	public GameObject parent;
	public GameObject puzzleForm;

	public bool unlocked = false;

	private static bool shown = false;
	private GameObject puzzle;

	void OnEnable() {
		puzzle = (GameObject)Instantiate(puzzleForm);

		Camera.main.GetComponent<MouseLook> ().enabled = false;
		puzzle.GetComponent<Canvas>().enabled = true;

		Transform panel = puzzle.transform.Find ("Panel");
		panel.Find ("Question").GetComponent<Text> ().text = question;

		int i = 0;
		panel.Find ("Continue").GetComponent<PuzzleChecker> ().puzzle = this;
		foreach (Transform child in panel.Find("Choices")) {
			child.Find("Text").GetComponent<Text>().text = choices [i];
			child.GetComponent<PuzzleChecker> ().puzzle = this;
			if (child.name == answer.ToString ())
				child.name = "Correct";
			i++;
		}
	}

	public void Continue(bool passed) {
		Camera.main.GetComponent<MouseLook> ().enabled = !shown;

		Destroy (puzzle);

		if (passed) {
			unlocked = true;
		} else {
			Destroy (this);
		}
	}
}