using UnityEngine;
using System.Collections;

public class WeaponSystemGun : MonoBehaviour {

  public GameObject LaserPrefabGreen;
  public GameObject LaserPrefabRed;
  public GameObject LaserPrefabBlue;

  private GameObject CurrentWeaponPrefab;
  private int CurrentWeapon;
  private float nextFire;
  private float CurrentFireRate;

  private void Start ()
  {
    nextFire = CurrentFireRate;
    CurrentWeapon = GameControl.control.CurrentWeapon;
    CurrentWeaponPrefab = LaserPrefabBlue;
    CurrentFireRate = GameControl.control.CurrentFireRate;
  }

  private void FixedUpdate ()
  {
    if(Input.GetButton("Fire4") && Time.time > nextFire)
    {
      nextFire = Time.time + CurrentFireRate;
      Instantiate(CurrentWeaponPrefab, transform.position, transform.rotation);
    }
    CurrentWeapon = GameControl.control.CurrentWeapon;
    CurrentFireRate = GameControl.control.CurrentFireRate;
    if(CurrentWeapon == 1)
      CurrentWeaponPrefab = LaserPrefabGreen;
    if(CurrentWeapon == 2)
      CurrentWeaponPrefab = LaserPrefabRed;
    if(CurrentWeapon == 3)
      CurrentWeaponPrefab = LaserPrefabBlue;
  }

}
