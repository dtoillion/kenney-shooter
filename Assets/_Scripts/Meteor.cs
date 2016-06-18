using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	public GameObject[] MedMeteors;
	private Rigidbody2D rb;
	private Vector3 originPosition;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddTorque(Random.Range(-15,15));
		rb.AddForce(transform.right * (Random.Range(-100,-450)));
	}

	void OnTriggerEnter2D(Collider2D trig)
  {
    if ((trig.gameObject.tag == "Projectile") || (trig.gameObject.tag == "EnemyLaser"))
    {
			Destroy(trig.gameObject, 0);
			if(trig.gameObject.tag == "Projectile")
        GameControl.control.score += 10;
     	originPosition = transform.position;
     	for (int i = 0; i < 5; i++)
     	{
				Instantiate(MedMeteors[Random.Range(0, MedMeteors.Length)], originPosition, Quaternion.identity);
     	}
			Destroy(gameObject, 0);
      }
  }

}
