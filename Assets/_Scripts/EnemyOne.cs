using UnityEngine;
using System.Collections;

public class EnemyOne : MonoBehaviour {

	public GameObject ExplosionPrefab;
	public GameObject ImpactPrefab;
	private GameObject LaserPrefab;
	public GameObject[] LaserPrefabs;
	public GameObject[] Pickups;
	private float health;
	private bool shoots = false;
	private float sf;
	private float burstRate;
  private float burstLength;
  private float fireRate;
  private float startDelay = 0.5f;

	void Start ()
	{
		SetupEnemy();
		if (shoots)
			StartCoroutine(PewPewPew());
	}

	void SetupEnemy ()
	{
		transform.rotation = Quaternion.Euler(0, 0, 270);
		LaserPrefab = LaserPrefabs[Random.Range(0, LaserPrefabs.Length)];
    health = Random.Range(1, (GameControl.control.CurrentLevel));
    sf = (Random.Range(1f, 10f));
		if(sf >= 5f)
		{
			shoots = true;
			burstRate = Random.Range(1f, 3f);
			burstLength = Random.Range(1f, GameControl.control.CurrentLevel);
			fireRate = Random.Range(0.40f, 1f);
		}
	}

  IEnumerator PewPewPew ()
  {
    yield return new WaitForSeconds (startDelay);
    while (true)
    {
      for (int i = 0; i < burstLength; i++)
      {
        Instantiate(LaserPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds (fireRate);
      }
      yield return new WaitForSeconds (burstRate);
    }
  }

	void OnTriggerEnter2D(Collider2D trig) {
    if((trig.gameObject.tag == "Projectile"))
    {
    	health -= 1;
    	Instantiate(ImpactPrefab, transform.position, transform.rotation);
    	if(trig.gameObject.tag == "Projectile")
    		Destroy(trig.gameObject, 0);
    	if(health <= 0) {
        GameControl.control.kills += 1f;
        if(shoots)
          GameControl.control.score += (50 + GameControl.control.CurrentLevel * GameControl.control.kills);
        GameControl.control.score += (100 + GameControl.control.CurrentLevel * GameControl.control.kills);
				Instantiate(ExplosionPrefab, transform.position, transform.rotation);
				ExplosionPrefab.transform.parent = null;
				for (int i = 0; i < 1; i++)
				{
					Instantiate(Pickups[Random.Range(1, Pickups.Length)], transform.position, Quaternion.identity);
				}
				Destroy(gameObject, 0.1f);
    	}
    }
  }

}
