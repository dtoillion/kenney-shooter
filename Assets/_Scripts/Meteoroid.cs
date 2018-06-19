using UnityEngine;
using System.Collections;

public class Meteoroid : MonoBehaviour {

  public GameObject[] Meteors;
	public GameObject MeteorExplosion;

  public float health = 3f;
  public float ScoreValue = 1;

  public bool initialForce = false;
  public bool smallMeteor = false;

  private Rigidbody2D rb;
  private Vector3 originPosition;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();

    if(initialForce)
    {
      rb.AddForce(transform.right * Random.Range(-1500,1500));
      rb.AddForce(transform.up * Random.Range(-1500,1500));
    }

		rb.AddTorque(Random.Range(-100,100));
	}

	void OnTriggerEnter2D(Collider2D trig)
  {
    if ((trig.gameObject.tag == "Projectile") || (trig.gameObject.tag == "EnemyLaser"))
    {
      health--;
      Instantiate(MeteorExplosion, transform.position, transform.rotation);
      Destroy(trig.gameObject, 0);
      if(health <= 0)
      {
        if(trig.gameObject.tag == "Projectile")
          GameControl.control.score += (ScoreValue);
        originPosition = transform.position;
        MeteorExplosion.transform.parent = null;
        if(!smallMeteor) {
          for (int i = 0; i < 5; i++)
          {
            Instantiate(Meteors[Random.Range(0, Meteors.Length)], originPosition, Quaternion.identity);
          }
        }
        Destroy(gameObject, 0);
      }

    }
  }

}
