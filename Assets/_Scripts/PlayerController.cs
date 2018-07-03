using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject ExplosionPrefab;
	public GameObject ImpactPrefab;
	private float XInputValue;
  private float YInputValue;
	private Rigidbody2D rb;
	private bool crash;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		crash = false;
	}

	private void Update ()
	{
    XInputValue = Input.GetAxis("Horizontal");
		YInputValue = Input.GetAxis("Vertical");

		if(GameControl.control.health <= 0)
		{
			Instantiate(ExplosionPrefab, transform.position, transform.rotation);
			ExplosionPrefab.transform.parent = null;
      gameObject.SetActive(false);
		}
	}

	private void FixedUpdate ()
	{
    if((YInputValue != 0) && !(crash))
      MoveShip ();
		if((XInputValue != 0) && !(crash))
			StrafeShip ();
    if(Input.GetKey("escape"))
      GameControl.control.PauseGame();
	}

	void OnTriggerEnter2D(Collider2D trig) {
    if (trig.gameObject.tag == "EnemyLaser")
    {
      GameControl.control.health -=1;
     	Destroy(trig.gameObject, 0);
			Instantiate(ImpactPrefab, transform.position, transform.rotation);
    }
  }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.tag == "Target") || (collision.gameObject.tag == "Boss") && !(crash))
		{
			crash = true;
			Invoke("Crashed", 0.7f);
			Instantiate(ImpactPrefab, transform.position, transform.rotation);
		}
	}

	private void Crashed ()
	{
		crash = false;
	}

  private void MoveShip () {
		rb.AddForce(transform.up * -YInputValue * GameControl.control.Speed);
  }

  private void StrafeShip ()
  {
    rb.AddForce(transform.right * XInputValue * GameControl.control.Speed);
	}

}
