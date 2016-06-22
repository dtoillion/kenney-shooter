using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

	public float Speed = 2f;
	private Rigidbody2D rb;
	AudioSource audio;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		audio = GetComponent<AudioSource>();
	}

	private void Start ()
	{
		audio.pitch = (Random.Range(0.7f, 1.2f));
		rb.AddForce(transform.up * Speed);
	}

}
