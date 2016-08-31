using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public bool BossPresent = true;
	public GameObject GamePauseCanvas;
	public GameObject GameOverCanvas;
	public GameObject GameWinCanvas;
	public GameObject PlayerShip;
	public float score;
	public float kills;
	public float health;
	public float Speed;
	public float CurrentFireRate;
	public float ammo;
	public float CurrentLevel = 1;
	public int CurrentWeaponInt = 0;
	public Text scoreHUD;
	public Text currentweaponHUD;
	public Text killsHUD;
	public Text healthHUD;
	public Text speedHUD;
	public Text firerateHUD;
	public Text ammoHUD;
	public Text currentlevelHUD;

	private bool Paused = false;

	void Update ()
	{
		currentweaponHUD.text = ("Weapon: " + GameControl.control.CurrentWeaponInt.ToString ("n0"));
		healthHUD.text = ("Health: " + GameControl.control.health.ToString ("n0"));
		scoreHUD.text = GameControl.control.score.ToString ("n0");
		killsHUD.text = ("Kills: " + GameControl.control.kills.ToString ("n0"));
		speedHUD.text = ("Speed: " + GameControl.control.Speed.ToString ("n0"));
		firerateHUD.text = ("Rate:" + GameControl.control.CurrentFireRate.ToString ("F"));
		ammoHUD.text = ("Ammo: " + GameControl.control.ammo.ToString ("n0"));
		currentlevelHUD.text = ("Wave " + CurrentLevel);
	}

	void Awake ()
	{
		control = this;
	}

	public void CheckBoss ()
	{
		if(GameObject.FindGameObjectsWithTag("Boss").Length >= 1)
		{
			Debug.Log("boss detected");
		} else {
			if(BossPresent)
			  BossPresent = false;
			else
			  BossPresent = true;
		}
	}

	public void PauseGame ()
	{
		if(!Paused)
		{
			Paused = true;
			GamePauseCanvas.SetActive(true);
			Time.timeScale = 0;
		} else {
			Paused = false;
		  GamePauseCanvas.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void GameOver ()
	{
		GameOverCanvas.SetActive(true);
		Time.timeScale = 0;
	}

	public void GameWin ()
	{
		GameWinCanvas.SetActive(true);
		Time.timeScale = 0;
	}

	public void ResetGame ()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Level001");
	}

}
