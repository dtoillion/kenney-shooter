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
	public bool SpawnPlayer = true;
	public GameObject GamePauseCanvas;
	public GameObject GameOverCanvas;
	public GameObject GameWinCanvas;
	public GameObject PlayerShip;
	public float score;
	public float health;
	public float Speed;
	public float CurrentFireRate;
	public float ammo;
	public float CurrentLevel = 1;
	public int CurrentWeaponInt = 0;
	public Text scoreHUD;
	public Text ammoHUD;
	public Text currentlevelHUD;

	private bool Paused = false;


	void Awake ()
	{
		if (control == null)
		  control = this;
		else if (control != this)
		  Destroy(gameObject);

		// DontDestroyOnLoad(gameObject);
		if(SpawnPlayer)
		  Instantiate(PlayerShip, new Vector3(0, 0, 0), transform.rotation);
	}

	void Update ()
	{
		scoreHUD.text = ("Score: " + GameControl.control.score.ToString ("n0"));
		ammoHUD.text = ("Ammo: " + GameControl.control.ammo.ToString ("n0"));
	}

	public void CheckBoss ()
	{
		if(GameObject.FindGameObjectsWithTag("Boss").Length == 0)
		{
			BossPresent = false;
		} else {
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
	}

	public void GameWin ()
	{
		GameWinCanvas.SetActive(true);
		currentlevelHUD.text = ("You Win!");
	}

	public void ResetGame ()
	{
		SceneManager.LoadScene("Survival");
	}

}
