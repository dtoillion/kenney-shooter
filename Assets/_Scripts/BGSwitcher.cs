using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BGSwitcher : MonoBehaviour {

  public static BGSwitcher control;
  public GameObject[] bgImages;

	void Awake ()
  {
    control = this;
    bgImages[0].SetActive(true);
	}

  public void UpdateBackground()
  {
    bgImages[0].SetActive(false);
    bgImages[1].SetActive(false);
    bgImages[2].SetActive(false);
    if(GameControl.control.CurrentLevel <= 5) {
      bgImages[0].SetActive(true);
    } else if(GameControl.control.CurrentLevel <= 10) {
      bgImages[1].SetActive(true);
    } else {
      bgImages[2].SetActive(true);
    }
  }

}
