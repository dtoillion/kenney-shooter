﻿using UnityEngine;
using System.Collections;

public class PlayerExplosion : MonoBehaviour {

	public float Lifetime = 3f;

	void Start ()
  {
		Destroy(gameObject, Lifetime);
    Invoke("Death", 1f);
	}

  private void Death()
  {
    GameControl.control.GameOver();
  }

}