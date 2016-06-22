using UnityEngine;
using System.Collections;

public class SmallMeteor : MonoBehaviour {

	private Rigidbody2D rb;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddTorque(Random.Range(-30,30));
	}

	void OnTriggerEnter2D(Collider2D trig)
	{
    if ((trig.gameObject.tag == "Projectile") || (trig.gameObject.tag == "EnemyLaser"))
    {
      //Destroy(trig.gameObject, 0);
      if (trig.gameObject.tag == "Projectile")
			  GameControl.control.score += 50f;
			Destroy(gameObject, 0);
   	}
  }

}
