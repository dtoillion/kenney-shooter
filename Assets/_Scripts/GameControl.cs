using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	
	public static GameControl control;

	public float score = 0f;
	public float health= 100f;
	public float fireRate = 1f;
	public float Speed = 1f;
	public Text scoreHUD;
	public Text healthHUD;
	public GameObject GameOverCanvas;

	void Update () 
	{
		healthHUD.text = "Health: " + GameControl.control.health.ToString ("n0");
		scoreHUD.text = "Score: " + GameControl.control.score.ToString ("n0");
		if(health <= 0)
		{
			Invoke("GameOver", 1);
		}
	}

	void Awake ()
	{
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}

		scoreHUD.text = "Score: " + GameControl.control.score.ToString ("n0");
		healthHUD.text = "Health: " + GameControl.control.health.ToString ("n0");
	}

	public void GameOver ()
	{
		GameOverCanvas.SetActive(true);
		Time.timeScale = 0;
	}

	public void GameWin ()
	{
		Debug.Log("WIN");
	}

	public void Save ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		PlayerData data = new PlayerData ();
		data.score = score;
		data.health = health;
		bf.Serialize (file, data);
		file.Close ();
	}
	
	public void Load ()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();
			
			score = data.score;
			health = data.health;
		}
	}

}

[Serializable]
class PlayerData
{
	public float score;
	public float health;
}
