using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

	public float Speed = 2f;
	private Rigidbody2D rb;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Start ()
	{
		rb.AddForce(transform.up * Speed);
	}

}
