using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

  public void Quit ()
  {
  	Application.Quit();
  }

  public void Retry ()
  {
    GameControl.control.PauseGame();
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
