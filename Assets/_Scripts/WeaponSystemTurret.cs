using UnityEngine;
using System.Collections;

public class WeaponSystemTurret : MonoBehaviour {

	public GameObject LaserPrefabGreen;
	public GameObject LaserPrefabRed;
	public GameObject LaserPrefabBlue;

	private GameObject CurrentWeapon;
	private float CurrentFireRate;
	private float nextFire = 0.0f;
	private float RightYInputValue;
	private float RightXInputValue;

	private void Start ()
	{
		CurrentWeapon = LaserPrefabBlue;
		CurrentFireRate = GameControl.control.fireRateBlue;
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

	private void TurnGun ()
	{
		var angle = Mathf.Atan2(RightXInputValue, RightYInputValue) * Mathf.Rad2Deg - 180;
        transform.rotation = Quaternion.Euler(0, 0, angle);
	}

}
