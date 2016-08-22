using UnityEngine;
using System.Collections;

public class WeaponSystemTurret : MonoBehaviour {

	public GameObject[] CurrentWeaponPrefab;
	private int CurrentWeaponInt = 0;
	private float CurrentFireRate;
	private float nextFire = 0.0f;
	private float RightYInputValue;
	private float RightXInputValue;

	private void Start ()
	{
		CurrentWeaponInt = GameControl.control.CurrentWeaponInt;
		CurrentFireRate = GameControl.control.CurrentFireRate;
		nextFire = CurrentFireRate;
	}

	private void Update ()
	{
		RightYInputValue = Input.GetAxis("RVertical");
		RightXInputValue = Input.GetAxis("RHorizontal");
	}

	private void FixedUpdate ()
	{
		if(((RightXInputValue != 0) || (RightYInputValue != 0)))
		{
			TurnGun ();
		}

		if(Input.GetButton("Fire4") && GameControl.control.ammo >=1 && Time.time > nextFire)
		{
			CurrentWeaponInt = GameControl.control.CurrentWeaponInt;
			CurrentFireRate = GameControl.control.CurrentFireRate;
			nextFire = Time.time + CurrentFireRate;
			Instantiate(CurrentWeaponPrefab[CurrentWeaponInt], transform.position, transform.rotation);
			GameControl.control.ammo -= 1;
		}
	}

	private void TurnGun ()
	{
		var angle = Mathf.Atan2(RightXInputValue, RightYInputValue) * Mathf.Rad2Deg - 180;
    transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
