using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

  public GameObject loadingScreenPrefab;

  public void ExitGame()
  {
    Application.Quit();
  }

  public void StartSurvivalMode()
  {
    loadingScreenPrefab.SetActive(true);
    SceneManager.LoadScene("Survival");
  }

  public void StartCampaignMode()
  {
    loadingScreenPrefab.SetActive(true);
    SceneManager.LoadScene("Campaign");
  }

}
