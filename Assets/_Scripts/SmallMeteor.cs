using UnityEngine;
using System.Collections;

public class SmallMeteor : MonoBehaviour {

	private Rigidbody2D rb;
  public GameObject MeteorExplosion;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
    rb.AddTorque(Random.Range(-300,300));
    rb.AddForce(transform.right * Random.Range(-2000,2000));
    rb.AddForce(transform.up * Random.Range(-2000,2000));
	}

	void OnTriggerEnter2D(Collider2D trig)
	{
    if ((trig.gameObject.tag == "Projectile") || (trig.gameObject.tag == "EnemyLaser"))
    {
      Destroy(trig.gameObject, 0);
      if (trig.gameObject.tag == "Projectile")
			  GameControl.control.score += (500 + GameControl.control.CurrentLevel * GameControl.control.kills);
			Instantiate(MeteorExplosion, transform.position, transform.rotation);
      MeteorExplosion.transform.parent = null;
      Destroy(gameObject, 0);
   	}
  }

}
