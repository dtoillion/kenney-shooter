﻿using UnityEngine;
using System.Collections;

public class BGFader : MonoBehaviour {

  public SpriteRenderer bgSprite;
  public float min = 0.0f;
  public float max = 1f;
  public float duration = 3.0f;
  private float startTime;
  public bool faded = false;

  void Start ()
  {
    startTime = Time.time;
    Invoke("EndFade", duration);
  }

	void Update ()
  {
    if(!faded)
    {
      float t = (Time.time - startTime) / duration;
      bgSprite.color = new Color(169f,187f,221f,Mathf.SmoothStep(min, max, t));
    }
	}

  void EndFade ()
  {
    faded = true;
  }

}
