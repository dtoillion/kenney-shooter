using UnityEngine;
using System.Collections;

public class BossExplosion : MonoBehaviour {

  public float Lifetime = 3f;

	void Awake ()
  {
    Invoke("Death", 1f);
  }

  private void Death()
  {
    GameControl.control.CheckBoss();
    Destroy(gameObject, Lifetime);
  }

}
