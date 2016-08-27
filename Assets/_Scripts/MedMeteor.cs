using UnityEngine;
using System.Collections;

public class MedMeteor : MonoBehaviour {

	public GameObject[] SmallMeteors;
  public GameObject MeteorExplosion;
	private Rigidbody2D rb;
	private Vector3 originPosition;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddTorque(Random.Range(-500,500));
    rb.AddForce(transform.right * Random.Range(-5000,5000));
    rb.AddForce(transform.up * Random.Range(-5000,5000));
	}

	void OnTriggerEnter2D(Collider2D trig)
  {

    if ((trig.gameObject.tag == "Projectile") || (trig.gameObject.tag == "EnemyLaser"))
    {
			Destroy(trig.gameObject, 0);
      if (trig.gameObject.tag == "Projectile")
			  GameControl.control.score += (250 + GameControl.control.CurrentLevel * GameControl.control.kills);
     	originPosition = transform.position;
     	for (int i = 0; i < 5; i++)
     	{
  			Instantiate(SmallMeteors[Random.Range(0, SmallMeteors.Length)], originPosition, Quaternion.identity);
     	}
      Instantiate(MeteorExplosion, transform.position, transform.rotation);
      MeteorExplosion.transform.parent = null;
			Destroy(gameObject, 0);
    }
  }

}
