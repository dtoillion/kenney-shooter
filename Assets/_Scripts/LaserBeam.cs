using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour
{
	public float Speed = 2f;
	public float Lifetime = 2f;
	private Rigidbody2D rb;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		Destroy(gameObject, Lifetime);
	}

	private void Update ()
	{
		rb.AddForce(transform.up * Speed * Time.deltaTime);
	}

}
