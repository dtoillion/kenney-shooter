using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject ExplosionPrefab;
	public GameObject ImpactPrefab;
	private float YInputValue;
	private float XInputValue;
	private Rigidbody2D rb;
	private bool crash;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		crash = false;
	}

	private void Update ()
	{
		YInputValue = Input.GetAxis("Vertical");
		XInputValue = Input.GetAxis("Horizontal");

		if(GameControl.control.health <= 0)
		{
			Instantiate(ExplosionPrefab, transform.position, transform.rotation);
			ExplosionPrefab.transform.parent = null;
			gameObject.SetActive(false);
		}
	}

	private void FixedUpdate ()
	{
		if(((XInputValue != 0) || (YInputValue != 0)) && !(crash))
			MoveShip ();
    if(Input.GetKey("escape"))
      GameControl.control.PauseGame();
	}

	void OnTriggerEnter2D(Collider2D trig) {
    if (trig.gameObject.tag == "EnemyLaser")
    {
     	Destroy(trig.gameObject, 0);
      if(!PlayerUpgrades.control.Shielded)
     	  GameControl.control.health -= 1f;
      PlayerUpgrades.control.ResetShield();
			Instantiate(ImpactPrefab, transform.position, transform.rotation);
    }

    if (trig.gameObject.tag == "SpeedPickUp")
    {
      PlayerUpgrades.control.SpeedBoost();
    }

    if (trig.gameObject.tag == "FireRatePickUp")
    {
      PlayerUpgrades.control.FireRateBoost();
    }

    if (trig.gameObject.tag == "AmmoPickUp")
    {
      GameControl.control.ammo += 100f;
      GameControl.control.CurrentWeaponInt = (Random.Range(0, 29));
    }

    if (trig.gameObject.tag == "ShieldPickUp")
    {
      PlayerUpgrades.control.ShieldBoost();
    }

  }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.tag == "Target") || (collision.gameObject.tag == "Boss") && !(crash))
		{
			crash = true;
			Invoke("Crashed", 0.7f);
      if(!PlayerUpgrades.control.Shielded)
			  GameControl.control.health -= 1f;
      PlayerUpgrades.control.ResetShield();
			Instantiate(ImpactPrefab, transform.position, transform.rotation);
		}
	}

	private void Crashed ()
	{
		crash = false;
	}

	private void MoveShip ()
	{
		rb.AddForce(transform.right * YInputValue * GameControl.control.Speed);
		rb.AddForce(transform.up * XInputValue * GameControl.control.Speed);
	}

}
