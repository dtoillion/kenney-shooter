using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject ImpactPrefab;
  public GameObject ExplosionPrefab;
	private float health;

	void Start ()
	{
   SetupEnemy();
	}

	void SetupEnemy ()
	{
    health = Random.Range(1, (GameControl.control.CurrentLevel));
	}

	void OnTriggerEnter2D(Collider2D trig) {
    if(trig.gameObject.tag == "Projectile")
    {
    	health -= 1;
    	Instantiate(ImpactPrefab, transform.position, transform.rotation);
    	Destroy(trig.gameObject, 0);
    	if(health <= 0) {
        GameControl.control.score += (100 + GameControl.control.CurrentLevel);
				Instantiate(ExplosionPrefab, transform.position, transform.rotation);
				ExplosionPrefab.transform.parent = null;
				Destroy(gameObject, 0.1f);
    	}
    }
  }

}
