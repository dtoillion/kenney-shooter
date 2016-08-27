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
	public Text killsHUD;
	public Text healthHUD;
	public Text speedHUD;
	public Text firerateHUD;
	public Text ammoHUD;
	public Text currentlevelHUD;

	void Update ()
	{
		healthHUD.text = ("Shield: " + GameControl.control.health.ToString ("n0"));
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
		Instantiate(PlayerShip, transform.position, Quaternion.Euler(0, 0, 270));
	}

	public void CheckBoss ()
	{
		if((GameObject.Find("Boss01(Clone)")) || (GameObject.Find("Boss02(Clone)")) || (GameObject.Find("Boss03(Clone)")) || (GameObject.Find("Boss04(Clone)")))
		{
			Debug.Log("boss detected");
		} else {
			if(BossPresent)
			  BossPresent = false;
			else
			  BossPresent = true;
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
