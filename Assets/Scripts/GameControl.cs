using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GameControl : MonoBehaviour {

	public static GameControl control;

	private GameObject hud;
	private GameObject healthVal;
	private GameObject level;
	private GameObject menu;
	private GameObject messaging;

	public bool menuShown = false;

	private float dead = 0;

	public float health;

	// Use this for initialization
	void Awake () {
		if (!control) {
			DontDestroyOnLoad (gameObject);
			control = this;

			health = 100;
			hud = gameObject.transform.Find ("Canvas/HUD").gameObject;
			healthVal = hud.transform.Find ("HealthContainer/HealthVal").gameObject;
			level = hud.transform.Find ("Level").gameObject;
			menu = transform.Find ("PauseMenu").gameObject;
		} else {
			Destroy (gameObject);
		}
	}

	void Update() {
		UpdateHUD ();

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

		CloseWindows ();
	}

	public void New() {
		hud.SetActive (true);
		LoadLevel (1);
	}

	public void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.OpenOrCreate);

		PlayerData data = new PlayerData ();
		data.health = health;
		data.level = Application.loadedLevel;
		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load() {
		String path = Application.persistentDataPath + "/playerInfo.dat";
		if (File.Exists (path)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (path, FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close();

			health = data.health;
			hud.SetActive (true);
			LoadLevel (data.level);
		}
	}

	public void RestartLevel() {
		LoadLevel (Application.loadedLevel);
	}

	public void ToggleMenu() {
		menuShown = !menuShown;
		foreach (UnityEngine.Object c in UnityEngine.Object.FindObjectsOfType (typeof(Canvas))) {
			if (c.name != "Messaging")
				((Canvas) c).enabled = !menuShown;
		}
		menu.GetComponent<GUITexture>().enabled = menuShown;
		menu.transform.Find ("Canvas").gameObject.GetComponent<Canvas>().enabled = menuShown;

		if (Camera.main.GetComponent<MouseLook> ()) {
			Camera.main.GetComponent<MouseLook> ().enabled = !menuShown;
		};
	}

	void UpdateHUD() {
		healthVal.GetComponent<Slider>().value = health / 100;
		level.GetComponent<Text> ().text = "Level " + Application.loadedLevel;


		if (dead > 0) {
			dead -= Time.deltaTime;

			if (dead <= 0) {
				health = 100;
				LoadLevel (Application.loadedLevel);
			}
		}

		if (health <= 0 && dead == 0) {
			if (!messaging)
				messaging = GameObject.FindGameObjectsWithTag ("Messaging") [0];

			if (messaging) {
				dead = 5;
				messaging.transform.Find ("MessagingBox").Find ("Text").GetComponent<Text> ().text = "You have died. Respawning in 5 seconds";
				messaging.GetComponent<Canvas> ().enabled = true;
			}
		}
	}

	void CloseWindows() {
		if (Input.GetKeyDown (KeyCode.Return)) {
			GameObject.Find ("Messaging").SetActive (false);
			Camera.main.GetComponent<MouseLook> ().enabled = true;
		}
	}

	void LoadLevel(int level) {
		Application.LoadLevel (level);
		health = 100;
	}
}

[Serializable]
class PlayerData
{
	public float health;
	public int level;
}