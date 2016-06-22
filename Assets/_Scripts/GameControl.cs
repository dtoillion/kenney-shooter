using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public float score = 0f;
	public float health= 100f;
	public float Speed = 60f;
	public float CurrentFireRate = 0.5f;
	public bool SpawnPlayer = true;
	public Text scoreHUD;
	public Text healthHUD;
	public Text notification;
	public GameObject GameOverCanvas;
	public GameObject PlayerShip;
	public int CurrentWeapon = 1;
	public float CurrentLevel = 1;

	void Update ()
	{
		healthHUD.text = "Health: " + GameControl.control.health.ToString ("n0");
		scoreHUD.text = "Score: " + GameControl.control.score.ToString ("n0");
		notification.text = ("Level " + CurrentLevel);
	}

	void Awake ()
	{
		control = this;
		if(SpawnPlayer)
			Instantiate(PlayerShip, transform.position, Quaternion.Euler(0, 0, 270));
		scoreHUD.text = "Score: " + GameControl.control.score.ToString ("n0");
		healthHUD.text = "Health: " + GameControl.control.health.ToString ("n0");
		notification.text = ("Level " + CurrentLevel);
	}

	public void GameOver ()
	{
		GameOverCanvas.SetActive(true);
		Time.timeScale = 0;
	}

	public void ResetGame ()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Level001");
	}

}
