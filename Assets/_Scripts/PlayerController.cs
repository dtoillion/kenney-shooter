using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public GameObject LaserPrefab;
	public GameObject ExplosionPrefab;
	public GameObject ImpactPrefab;
	private float nextFire = 0.0f;
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
			Destroy(gameObject);
		}
	}
	
	private void FixedUpdate ()
	{
		if(((XInputValue != 0) || (YInputValue != 0)) && !(crash))
			TurnShip ();
		
		if(Input.GetButton("Fire1"))
			MoveShip ();
		
		if(Input.GetButton("Fire2") && Time.time > nextFire)
		{
			nextFire = Time.time + GameControl.control.fireRate;
			Instantiate(LaserPrefab, transform.position, transform.rotation);
		}
	}
	
	void OnTriggerEnter2D(Collider2D trig) {
        if (trig.gameObject.tag == "EnemyLaser")
        {
        	Destroy(trig.gameObject, 0);
        	GameControl.control.health-=10f;
			Instantiate(ImpactPrefab, transform.position, transform.rotation);
        }
    }
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.tag == "Target") && !(crash))
		{
			crash = true;
			rb.AddTorque(10);
			Invoke("Crashed", 2);
			GameControl.control.health-=10f;
			Instantiate(ImpactPrefab, transform.position, transform.rotation);
		}
	}

	private void Crashed ()
	{
		crash = false;
	}

	private void MoveShip ()
	{
		rb.AddForce(transform.up * GameControl.control.Speed);
	}

	private void TurnShip ()
	{
		var angle = Mathf.Atan2(XInputValue, YInputValue) * Mathf.Rad2Deg - 180;
        transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
