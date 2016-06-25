using UnityEngine;
using System.Collections;

public class WeaponSystemTurret : MonoBehaviour {

	public GameObject LaserPrefabGreen;
	public GameObject LaserPrefabRed;
	public GameObject LaserPrefabBlue;

	private GameObject CurrentWeaponPrefab;
	private int CurrentWeapon;
	private float CurrentFireRate;
	private float nextFire = 0.0f;
	private float RightYInputValue;
	private float RightXInputValue;

	private void Start ()
	{
		nextFire = CurrentFireRate;
	}

	private void Update ()
	{
		RightYInputValue = Input.GetAxis("RVertical");
		RightXInputValue = Input.GetAxis("RHorizontal");
		CurrentWeapon = GameControl.control.CurrentWeapon;
		CurrentFireRate = GameControl.control.CurrentFireRate;
		if(CurrentWeapon == 1)
		  CurrentWeaponPrefab = LaserPrefabGreen;
		if(CurrentWeapon == 2)
		  CurrentWeaponPrefab = LaserPrefabRed;
		if(CurrentWeapon == 3)
		  CurrentWeaponPrefab = LaserPrefabBlue;
	}

	private void FixedUpdate ()
	{
		if(((RightXInputValue != 0) || (RightYInputValue != 0)))
		{
			TurnGun ();
		}

		if(Input.GetButton("Fire4") && Time.time > nextFire)
		{
			nextFire = Time.time + CurrentFireRate;
			Instantiate(CurrentWeaponPrefab, transform.position, transform.rotation);
		}
	}

	private void TurnGun ()
	{
		var angle = Mathf.Atan2(RightXInputValue, RightYInputValue) * Mathf.Rad2Deg - 180;
    transform.rotation = Quaternion.Euler(0, 0, angle);
	}

}
