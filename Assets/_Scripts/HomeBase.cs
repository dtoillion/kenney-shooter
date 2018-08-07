using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HomeBase : MonoBehaviour {

  public void GoOnMission () {
    SceneManager.LoadScene("Survival");
  }

}
