using UnityEngine;
using System.Collections;

public class WeaponSystemGun : MonoBehaviour {

  public GameObject LaserPrefabGreen;
  public GameObject LaserPrefabRed;
  public GameObject LaserPrefabBlue;

  private GameObject CurrentWeapon;
  private float CurrentFireRate;
  private float nextFire = 0.0f;

  private void Start ()
  {
    CurrentWeapon = LaserPrefabBlue;
    CurrentFireRate = GameControl.control.fireRateBlue;
    nextFire = CurrentFireRate;
  }

  private void FixedUpdate ()
  {

    if(Input.GetButton("Fire1"))
    {
      CurrentWeapon = LaserPrefabGreen;
      CurrentFireRate = GameControl.control.fireRateGreen;
    }

    if(Input.GetButton("Fire2"))
    {
      CurrentWeapon = LaserPrefabRed;
      CurrentFireRate = GameControl.control.fireRateRed;
    }

    if(Input.GetButton("Fire3"))
    {
      CurrentWeapon = LaserPrefabBlue;
      CurrentFireRate = GameControl.control.fireRateBlue;
    }

    if(Input.GetButton("Fire4") && Time.time > nextFire)
    {
      nextFire = Time.time + CurrentFireRate;
      Instantiate(CurrentWeapon, transform.position, transform.rotation);
    }
  }

}
