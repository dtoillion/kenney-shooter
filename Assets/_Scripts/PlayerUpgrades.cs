using UnityEngine;
using System.Collections;

public class PlayerUpgrades : MonoBehaviour {

  public static PlayerUpgrades control;

  public GameObject[] Upgrades;
  private bool SpeedBoosted = false;
  private bool FireRateBoosted = false;

  void Awake ()
  {
    control = this;
  }

  public void SpeedBoost ()
  {
    if(!SpeedBoosted)
    {
      SpeedBoosted = true;
      GameControl.control.Speed *= 2f;
      GameControl.control.speedHUD.color = new Color(1f, 0f, 0f, 1f);
      Invoke("ResetSpeedBoost", 4);
    }
  }

  void ResetSpeedBoost ()
  {
    SpeedBoosted = false;
    GameControl.control.Speed *= 0.5f;
    GameControl.control.speedHUD.color = new Color(1f, 1f, 1f, 1f);
  }

  public void FireRateBoost ()
  {
    if(!FireRateBoosted)
    {
      FireRateBoosted = true;
      GameControl.control.CurrentFireRate *= 0.5f;
      GameControl.control.firerateHUD.color = new Color(1f, 0f, 0f, 1f);
      Invoke("ResetFireRate", 4);
    }
  }

  void ResetFireRate ()
  {
    FireRateBoosted = false;
    GameControl.control.CurrentFireRate *= 2f;
    GameControl.control.firerateHUD.color = new Color(1f, 1f, 1f, 1f);
  }

  public void UnlockGuns ()
  {
    if(GameControl.control.CurrentLevel - 1 <= Upgrades.Length)
      Upgrades[(int)GameControl.control.CurrentLevel - 2].SetActive(true);
	}


}
