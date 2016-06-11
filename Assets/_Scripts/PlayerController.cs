using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public GameObject ForwardThrust;
	public GameObject BackwardThrust;
	public GameObject LeftThrust;
	public GameObject RightThrust;
	public GameObject LaserPrefab;
	public AudioClip BeamClip;
	private float nextFire = 0.0f;
	private float YInputValue;
	private float XInputValue;
	private Rigidbody2D rb;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		ThrustControl();
	}

	private void Update ()
	{
		YInputValue = Input.GetAxis("Vertical");
		XInputValue = Input.GetAxis("Horizontal");
		if(GameControl.control.health <= 0)
		{
			Destroy(gameObject);
		}
	}
	
	private void FixedUpdate ()
	{
		MoveShip ();
		TurnShip ();
		ThrustControl ();
		if(Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + GameControl.control.fireRate;
			Instantiate(LaserPrefab, transform.position, transform.rotation);
			AudioSource.PlayClipAtPoint(BeamClip, new Vector3(0, 0, 0));
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Target")
		{
			GameControl.control.health-=10f;
		}
	}

	private void MoveShip ()
	{
		rb.AddForce(transform.up * YInputValue * GameControl.control.Speed * Time.deltaTime);
	}

	private void TurnShip ()
	{
		rb.AddForce(transform.right * XInputValue * GameControl.control.Speed * Time.deltaTime);
	}

	private void ThrustControl ()
	{
		if(YInputValue == 1) {
			ForwardThrust.SetActive(true);
		} else if(YInputValue == -1) {
			BackwardThrust.SetActive(true);
		} else {
			ForwardThrust.SetActive(false);
			BackwardThrust.SetActive(false);
		}
		if(XInputValue == 1) {
			RightThrust.SetActive(true);
		} else if(XInputValue == -1) {
			LeftThrust.SetActive(true);
		} else {
			RightThrust.SetActive(false);
			LeftThrust.SetActive(false);
		}
	}
}
