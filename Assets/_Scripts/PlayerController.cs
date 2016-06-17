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
			Destroy(gameObject);
		}
	}

	private void FixedUpdate ()
	{
		if(((XInputValue != 0) || (YInputValue != 0)) && !(crash))
			MoveShip ();
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
			Invoke("Crashed", 0.5f);
			GameControl.control.health -= 10f;
			Instantiate(ImpactPrefab, transform.position, transform.rotation);
		}
	}

	private void Crashed ()
	{
		crash = false;
	}

	private void MoveShip ()
	{
		rb.AddForce(transform.right * XInputValue * GameControl.control.Speed);
		rb.AddForce(transform.up * YInputValue * GameControl.control.Speed);
	}

}
