using UnityEngine;
using System.Collections;

public class MedMeteor : MonoBehaviour {
	
	public GameObject[] SmallMeteors;
	private Rigidbody2D rb;
	private Vector3 originPosition;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddTorque(Random.Range(-10,10));
	}

	void OnTriggerEnter2D(Collider2D trig) {
        if (trig.gameObject.tag == "Projectile")
        {
			Destroy(trig.gameObject, 0);
			GameControl.control.score+=5;
        	originPosition = transform.position;
        	for (int i = 0; i < 5; i++)
        	{
				Instantiate(SmallMeteors[Random.Range(0, SmallMeteors.Length)], originPosition, Quaternion.identity);	
        	}
			Destroy(gameObject, 0);
      }
    }
}
