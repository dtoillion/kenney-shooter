using UnityEngine;
using System.Collections;

public class BGFader : MonoBehaviour {

  public float colorVal = 1f;
  public float min = 0.0f;
  public float max = 1f;
  public float duration = 3.0f;
  public bool faded = false;

  private float startTime;
  private SpriteRenderer bgSprite;

  void Awake ()
  {
    bgSprite = GetComponent <SpriteRenderer>();
  }

  void OnEnable ()
  {
    faded = false;
    startTime = Time.time;
    bgSprite.color = new Color(0, 0, 0, 0);
    Invoke("EndFade", duration);
  }

  void Update ()
  {
    if(!faded)
    {
      float t = (Time.time - startTime) / duration;
      bgSprite.color = new Color(colorVal, colorVal, colorVal, Mathf.SmoothStep(min, max, t));
    }
	}

  void EndFade ()
  {
    faded = true;
  }

}
