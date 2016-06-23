using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

	public float Speed = 2f;
	private Rigidbody2D rb;
	AudioSource LaserAudio;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		LaserAudio = GetComponent<AudioSource>();
	}

	private void Start ()
	{
		LaserAudio.pitch = (Random.Range(0.6f, 1.2f));
		rb.AddForce(transform.up * Speed);
	}

}
