using UnityEngine;
using System.Collections;

public class SmallMeteor : MonoBehaviour {

	private Rigidbody2D rb;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddTorque(Random.Range(-10,10));
	}

	void OnTriggerEnter2D(Collider2D trig)
	{
    if (trig.gameObject.tag == "Projectile")
    {
			GameControl.control.score+=10f;
			Destroy(gameObject, 0);
   	}
  }

}
