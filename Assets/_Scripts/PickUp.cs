﻿using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

  public GameObject EffectPrefab;
  private Rigidbody2D rb;

  void Start ()
  {
    rb = GetComponent<Rigidbody2D>();
    rb.AddForce(transform.up * Random.Range(-90,90));
    rb.AddForce(transform.right * Random.Range(-90,90));
  }

	void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.tag == "Player")
		{
      Instantiate(EffectPrefab, transform.position, Quaternion.Euler(0, 0, 0));
      EffectPrefab.transform.parent = null;
			Destroy(gameObject);
		}
	}

}
