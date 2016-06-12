using UnityEngine;
using System.Collections;

public class EnemyOne : MonoBehaviour {

	public GameObject ExplosionPrefab;
	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * (Random.Range(-100,-300)));
	}
	
	void OnTriggerEnter2D(Collider2D trig) {
        if (trig.gameObject.tag == "Projectile")
        {
			GameControl.control.score++;
			Instantiate(ExplosionPrefab, transform.position, transform.rotation);
			ExplosionPrefab.transform.parent = null;
			Destroy(gameObject, 0.1f);
      }
    }
}
