﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

  public void Quit ()
  {
  	Application.Quit();
  }

  public void Retry ()
  {
    GameControl.control.ResetGame();
  }

  public void RTB () {
    SceneManager.LoadScene("HomeBase");
  }

  public void PauseGame ()
  {
    GameControl.control.PauseGame();
  }

}
