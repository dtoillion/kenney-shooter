using UnityEngine;
using System.Collections;

public class PlayerUpgrades : MonoBehaviour {

  public static PlayerUpgrades control;

  public GameObject Cockpit;
  public GameObject Engine;
  public GameObject Gun;
  public GameObject Gun2;
  public GameObject Gun3;

  void Awake ()
  {
    control = this;
  }

  public void UnlockGuns ()
  {
    if(GameControl.control.CurrentLevel == 2)
    {
      Engine.SetActive(true);
    }
    if(GameControl.control.CurrentLevel == 3)
    {
      Gun.SetActive(true);
      Cockpit.SetActive(true);
    }
    if(GameControl.control.CurrentLevel == 4)
    {
      Gun2.SetActive(true);
    }
    if(GameControl.control.CurrentLevel == 5)
    {
      Gun3.SetActive(true);
    }
	}
}
