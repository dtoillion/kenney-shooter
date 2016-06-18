using UnityEngine;
using System.Collections;

public class WeaponSystemGun : MonoBehaviour {

  public GameObject LaserPrefabRed;

  private GameObject CurrentWeapon;
  private float CurrentFireRate;
  private float nextFire = 0.0f;

  private void Start ()
  {
    CurrentWeapon = LaserPrefabRed;
    CurrentFireRate = GameControl.control.fireRateRed;
    nextFire = CurrentFireRate;
  }

  private void FixedUpdate ()
  {
    if(Input.GetButton("Fire4") && Time.time > nextFire)
    {
      nextFire = Time.time + CurrentFireRate;
      Instantiate(CurrentWeapon, transform.position, transform.rotation);
    }
  }

}
