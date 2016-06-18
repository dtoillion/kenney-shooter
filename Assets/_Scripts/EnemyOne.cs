using UnityEngine;
using System.Collections;

public class EnemyOne : MonoBehaviour {

	public GameObject ExplosionPrefab;
	public GameObject ImpactPrefab;
	public GameObject LaserPrefab;
	public float health = 30f;
	public bool shoots = false;
	public bool evasive = false;
	public bool speeder = false;
	public float sf;
	public float ef;
	public float ssf;

	private Rigidbody2D rb;

	void Start ()
	{
		SetupEnemy();
		transform.rotation = Quaternion.Euler(0, 0, 270);
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * (Random.Range(-100,-300)));
		if (evasive)
			InvokeRepeating("EvasiveMoves", 3, 3);
		if (shoots)
			InvokeRepeating("PewPewPew", 1, (Random.Range(2, 9)));
		if (speeder)
			InvokeRepeating("Speeder", 3, (Random.Range(3, 4)));
	}

	void SetupEnemy ()
	{
    sf = (Random.Range(1f, 10f));
		ef = (Random.Range(1f, 10f));
		ssf = (Random.Range(1f, 10f));
		if(sf >= 5f)
			shoots = true;
		if(ef >= 4f)
			evasive = true;
		if(ssf >= 4f)
			speeder = true;
	}

	void EvasiveMoves ()
	{
		rb.AddForce(transform.up * (Random.Range(-50,-100)));
	}

	void PewPewPew ()
	{
		Instantiate(LaserPrefab, transform.position, transform.rotation);
	}

	void Speeder ()
	{
		rb.AddForce(transform.right * (Random.Range(-70,70)));
	}

	void OnTriggerEnter2D(Collider2D trig) {
    if((trig.gameObject.tag == "Projectile") || (trig.gameObject.tag == "Target"))
    {
    	health -= 10;
    	Instantiate(ImpactPrefab, transform.position, transform.rotation);
    	if(trig.gameObject.tag == "Projectile")
    		Destroy(trig.gameObject, 0);
    	if(health <= 0) {
	    	if(evasive)
					GameControl.control.score += 50;
	    	if(shoots)
					GameControl.control.score += 50;
				GameControl.control.score += 100;
				Instantiate(ExplosionPrefab, transform.position, transform.rotation);
				ExplosionPrefab.transform.parent = null;
				Destroy(gameObject, 0.1f);
    	}
    }
  }

}
