using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

  public float health = 3f;
  public GameObject ImpactPrefab;
  public GameObject ExplosionPrefab;
  public GameObject[] Pickups;

  void Awake () {
    health = (10 + Random.Range(1, GameControl.control.CurrentLevel));
  }

  void OnTriggerEnter2D(Collider2D trig) {
    if((trig.gameObject.tag == "Projectile"))
    {
      health -= 1;
      Instantiate(ImpactPrefab, transform.position, transform.rotation);
      Destroy(trig.gameObject, 0);
      if(health <= 0) {
        GameControl.control.score += 1000;
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        ExplosionPrefab.transform.parent = null;
        for (int i = 0; i < 3; i++)
        {
          Instantiate(Pickups[Random.Range(0, Pickups.Length)], transform.position, Quaternion.identity);
        }
        Destroy(gameObject, 0);
      }
    }
  }

}
