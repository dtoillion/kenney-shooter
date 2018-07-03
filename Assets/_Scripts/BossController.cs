using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

  public float health = 3f;
  public float scoreValue = 100f;
  public GameObject ImpactPrefab;
  public GameObject ExplosionPrefab;

  void OnTriggerEnter2D(Collider2D trig) {
    if((trig.gameObject.tag == "Projectile"))
    {
      health -= 1;
      Instantiate(ImpactPrefab, transform.position, transform.rotation);
      Destroy(trig.gameObject, 0);

      if(health <= 0) {
        GameControl.control.score += scoreValue;
        GameControl.control.kills += 1f;
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        ExplosionPrefab.transform.parent = null;
        Destroy(gameObject, 0);
      }
    }
  }

}
