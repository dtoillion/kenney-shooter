using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

  public GameObject[] MedMeteors;
	public GameObject MeteorExplosion;
  public float health = 3f;
  public bool super = false;

  private Rigidbody2D rb;
  private Vector3 originPosition;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddTorque(Random.Range(-500,500));
    if(!super)
    {
      rb.AddForce(transform.right * Random.Range(-5000,5000));
      rb.AddForce(transform.up * Random.Range(-5000,5000));
    }
	}

	void OnTriggerEnter2D(Collider2D trig)
  {
    if ((trig.gameObject.tag == "Projectile") || (trig.gameObject.tag == "EnemyLaser"))
    {
      health--;
      Instantiate(MeteorExplosion, transform.position, transform.rotation);
      Destroy(trig.gameObject, 0);
      if(health <=0)
      {
        if(trig.gameObject.tag == "Projectile")
          GameControl.control.score += (100 + GameControl.control.CurrentLevel * GameControl.control.kills);
        originPosition = transform.position;
        Instantiate(MeteorExplosion, transform.position, transform.rotation);
        MeteorExplosion.transform.parent = null;
        for (int i = 0; i < 5; i++)
        {
          Instantiate(MedMeteors[Random.Range(0, MedMeteors.Length)], originPosition, Quaternion.identity);
        }
        Destroy(gameObject, 0);
      }

    }
  }

}
