using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public int sceneToLoad;

	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 50, 130, 40), "NEW GAME")) {
			Application.LoadLevel("maze1");

			PlayerPrefs.SetInt("health", 100);
		}
	}
}
