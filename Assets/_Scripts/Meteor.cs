using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {
	
	public GameObject[] MedMeteors;
	private Rigidbody2D rb;
	private Vector3 originPosition;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddTorque(Random.Range(-10,10));
		rb.AddForce(transform.up * (Random.Range(-100,-400)));
	}

	void OnTriggerEnter2D(Collider2D trig) {
        if (trig.gameObject.tag == "Projectile")
        {
			//Destroy(trig.gameObject, 0);
			GameControl.control.score++;
        	originPosition = transform.position;
        	for (int i = 0; i < 5; i++)
        	{
				Instantiate(MedMeteors[Random.Range(0, MedMeteors.Length)], originPosition, Quaternion.identity);	
        	}
			Destroy(gameObject, 0);
      }
    }
}
