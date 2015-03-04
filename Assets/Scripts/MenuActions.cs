using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MenuActions : MonoBehaviour {
	public int sceneToLoad;

	private GameControl control;

	void Awake() {
		control = GameObject.Find ("GameControl").GetComponent<GameControl> ();
	}

	public void New() {
		Application.LoadLevel(1);
	}

	public void Save() {
		control.Save();
	}

	public void SaveAndQuit() {
		control.Save();
		Debug.Log ("HERE");
		Application.Quit();
	}

	public void Load() {
		control.Load();
	}

	public void TogglePauseMenu() {
		control.ToggleMenu ();
	}
}