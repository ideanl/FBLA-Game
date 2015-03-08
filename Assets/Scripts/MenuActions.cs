using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MenuActions : MonoBehaviour {
	public int sceneToLoad;
	public static bool instructionsShown = false;

	private GameControl control;

	void Awake() {
		control = GameObject.Find ("GameControl").GetComponent<GameControl> ();
	}

	public void New() {
		control.New ();
	}

	public void Save() {
		control.Save();
	}

	public void SaveAndQuit() {
		control.Save();
		Application.Quit();
	}

	public void Load() {
		control.Load();
	}

	public void RestartZone() {
		control.RestartLevel ();
		TogglePauseMenu ();
	}

	public void TogglePauseMenu() {
		control.ToggleMenu ();
	}

	public void Exit() {
		Application.Quit ();
	}

	public void ToggleInstructions() {
		instructionsShown = !instructionsShown;
		GameObject.Find ("Instructions").GetComponent<Canvas>().enabled = instructionsShown;
		GameObject.Find ("MenuActions").GetComponent<Canvas>().enabled = !instructionsShown;
	}
}