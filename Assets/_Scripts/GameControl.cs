using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public bool SpawnPlayer = true;
	public bool BossPresent = true;
	public GameObject GameOverCanvas;
	public GameObject PlayerShip;
	public float score;
	public float health;
	public float Speed;
	public float CurrentFireRate;
	public float CurrentLevel = 1;
	public int CurrentWeaponInt = 0;
	public Text scoreHUD;
	public Text healthHUD;
	public Text speedHUD;
	public Text firerateHUD;
	public Text currentlevelHUD;

	void Update ()
	{
		healthHUD.text = "Health: " + GameControl.control.health.ToString ("n0");
		scoreHUD.text = "Score: " + GameControl.control.score.ToString ("n0");
		speedHUD.text = "Speed: " + GameControl.control.Speed.ToString ("n0");
		firerateHUD.text = "Fire Rate: " + GameControl.control.CurrentFireRate.ToString ("F");
		currentlevelHUD.text = ("Wave " + CurrentLevel);
	}

	void Awake ()
	{
		control = this;
		if(SpawnPlayer)
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

	public void ResetGame ()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Level001");
	}

}
