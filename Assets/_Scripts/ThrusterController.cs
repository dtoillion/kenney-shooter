using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterController : MonoBehaviour {

  private Rigidbody2D rb;
  public ParticleSystem FrontThruster;
  public ParticleSystem RearThruster;
  public ParticleSystem LeftThruster;
  public ParticleSystem RightThruster;

  private void Start () {
    rb = transform.parent.GetComponent<Rigidbody2D>();
  }

  private void Update () {

    if (rb.velocity.x == 0) {
      RightThruster.Stop();
      LeftThruster.Stop();
    } else {
      RightThruster.Play();
      LeftThruster.Play();
    }

    if (rb.velocity.y == 0) {
      FrontThruster.Stop();
      RearThruster.Stop();
    } else {
      FrontThruster.Play();
      RearThruster.Play();
    }

  }

}
