using UnityEngine;
using System.Collections;

public class EnemyOne : MonoBehaviour {

	public GameObject ExplosionPrefab;
	public GameObject LaserPrefab;
	public bool shoots = true;
	private Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * (Random.Range(-100,-200)));
		if (shoots)
			InvokeRepeating("PewPewPew", 1, (Random.Range(2, 9)));
	}
	
	void PewPewPew ()
	{
		Instantiate(LaserPrefab, transform.position, transform.rotation);
	}

	void OnTriggerEnter2D(Collider2D trig) {
        if (trig.gameObject.tag == "Projectile")
        {
        	Destroy(trig.gameObject, 0);
			GameControl.control.score += 5;
			Instantiate(ExplosionPrefab, transform.position, transform.rotation);
			ExplosionPrefab.transform.parent = null;
			Destroy(gameObject, 0.1f);
      }
    }
}
