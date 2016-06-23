using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

  public GameObject loadingScreenPrefab;

  void Update()
  {
  	if(Input.GetKeyDown("escape"))
    {
     	Application.Quit();
    } else if(Input.anyKeyDown) {
      loadingScreenPrefab.SetActive(true);
      SceneManager.LoadScene("Level001");
    }
  }

}
