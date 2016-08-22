using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

  public GameObject[] CurrentWeaponPrefab;
  private int CurrentWeaponInt;
  private float CurrentFireRate;
  private float nextFire;

  private void Start ()
  {
    CurrentWeaponInt = GameControl.control.CurrentWeaponInt;
    CurrentFireRate = GameControl.control.CurrentFireRate;
    nextFire = CurrentFireRate;
  }

  private void FixedUpdate ()
  {
    if(Input.GetButton("Fire4") && GameControl.control.ammo >=1 && Time.time > nextFire)
    {
      CurrentWeaponInt = GameControl.control.CurrentWeaponInt;
      CurrentFireRate = GameControl.control.CurrentFireRate;
      nextFire = Time.time + CurrentFireRate;
      Instantiate(CurrentWeaponPrefab[CurrentWeaponInt], transform.position, transform.rotation);
      GameControl.control.ammo -= 1;
    }
  }
}
