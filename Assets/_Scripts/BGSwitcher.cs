using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BGSwitcher : MonoBehaviour {

  public static BGSwitcher control;
  public GameObject[] bgImages;
  public int CurrentLevelInt = 0;

	void Awake ()
  {
    control = this;
  }

  void Start ()
  {
    bgImages[CurrentLevelInt].SetActive(true);
  }

  public void UpdateBackground()
  {
    for(int i = 0; i < bgImages.Length; i++)
    {
      bgImages[i].SetActive(false);
    }
    if(CurrentLevelInt != bgImages.Length - 1)
    {
      CurrentLevelInt += 1;
    } else {
      CurrentLevelInt = 0;
    }
    bgImages[CurrentLevelInt].SetActive(true);
  }

}
