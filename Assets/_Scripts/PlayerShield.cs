using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour {

  public GameObject ImpactPrefab;

  void OnTriggerEnter2D(Collider2D trig)
  {
    if(trig.gameObject.tag == "EnemyLaser")
    {
      gameObject.SetActive(false);
    }
  }
}
