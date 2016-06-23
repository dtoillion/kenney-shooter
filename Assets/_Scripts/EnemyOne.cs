using UnityEngine;
using System.Collections;

public class EnemyOne : MonoBehaviour {

	public GameObject ExplosionPrefab;
	public GameObject ImpactPrefab;
	private GameObject LaserPrefab;
	public GameObject[] LaserPrefabs;
	public GameObject[] Pickups;
	public float health = 3f;
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
		if (evasive)
			InvokeRepeating("EvasiveMoves", 5, 3);
		if (shoots)
			InvokeRepeating("PewPewPew", 2, (Random.Range(2, 9)));
		if (speeder)
			InvokeRepeating("Speeder", 6, (Random.Range(1, 2)));
	}

	void SetupEnemy ()
	{
		LaserPrefab = LaserPrefabs[Random.Range(0, LaserPrefabs.Length)];
    sf = (Random.Range(1f, 10f));
		ef = (Random.Range(1f, 10f));
		ssf = (Random.Range(1f, 10f));
		if(GameControl.control.CurrentLevel >= 3)
		{
			if(sf >= 5f)
				shoots = true;
			if(ef >= 4f)
				evasive = true;
			if(ssf >= 4f)
				speeder = true;
		}
	}

	void EvasiveMoves ()
	{
		rb.AddForce(transform.right * (Random.Range(-100,100)));
		rb.AddForce(transform.up * (Random.Range(0,100)));
	}

	void PewPewPew ()
	{
		Instantiate(LaserPrefab, transform.position, transform.rotation);
	}

	void Speeder ()
	{
		rb.AddForce(transform.up * (Random.Range(-10,-20)));
	}

	void OnTriggerEnter2D(Collider2D trig) {
    if((trig.gameObject.tag == "Projectile") || (trig.gameObject.tag == "Target"))
    {
    	health -= 1;
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
				for (int i = 0; i < 1; i++)
				{
					Instantiate(Pickups[Random.Range(0, Pickups.Length)], transform.position, Quaternion.identity);
				}
				Destroy(gameObject, 0.1f);
    	}
    }
  }

}
