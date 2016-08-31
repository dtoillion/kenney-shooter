using UnityEngine;
using System.Collections;

public class PlayerUpgrades : MonoBehaviour {

  public static PlayerUpgrades control;

  public GameObject[] Upgrades;
  public GameObject EffectPrefab;
  public GameObject Shield;
  public bool SpeedBoosted = false;
  public bool FireRateBoosted = false;
  public bool Shielded = false;

  void Awake ()
  {
    control = this;
  }

  public void ShieldBoost ()
  {
    GameControl.control.health += 2f;
    if(!Shielded)
    {
      Shielded = true;
      Shield.SetActive(true);
    }
  }

  public void ResetShield ()
  {
    Shielded = false;
    Shield.SetActive(false);
  }

  public void SpeedBoost ()
  {
    if(!SpeedBoosted)
    {
      SpeedBoosted = true;
      GameControl.control.Speed += 20f;
      GameControl.control.speedHUD.color = new Color(1f, 0f, 0f, 1f);
      Invoke("ResetSpeedBoost", 4);
    }
  }

  void ResetSpeedBoost ()
  {
    SpeedBoosted = false;
    GameControl.control.Speed -= 20f;
    GameControl.control.speedHUD.color = new Color(1f, 1f, 1f, 1f);
  }

  public void FireRateBoost ()
  {
    if(!FireRateBoosted)
    {
      FireRateBoosted = true;
      GameControl.control.CurrentFireRate *= 0.5f;
      GameControl.control.firerateHUD.color = new Color(1f, 0f, 0f, 1f);
      Invoke("ResetFireRate", 5);
    }
  }

  void ResetFireRate ()
  {
    FireRateBoosted = false;
    GameControl.control.CurrentFireRate *= 2f;
    GameControl.control.firerateHUD.color = new Color(1f, 1f, 1f, 1f);
  }

  public void LevelUp ()
  {
    if(GameControl.control.CurrentLevel - 1 <= Upgrades.Length)
    {
      GameControl.control.Speed += 5f;
      Upgrades[(int)GameControl.control.CurrentLevel - 2].SetActive(true);
      Instantiate(EffectPrefab, transform.position, Quaternion.Euler(0, 0, 0));
      EffectPrefab.transform.parent = null;
    }
	}


}
