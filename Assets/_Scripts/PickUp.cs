using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

  public GameObject EffectPrefab;
  private Rigidbody2D rb;

  void Start ()
  {
    rb = GetComponent<Rigidbody2D>();
    rb.AddTorque(Random.Range(-10,10));
    rb.AddForce(transform.up * Random.Range(-70,70));
  }

	void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.tag == "Player")
		{
      GameControl.control.score += 10f;
      Instantiate(EffectPrefab, transform.position, Quaternion.Euler(0, 0, 0));
      EffectPrefab.transform.parent = null;
			Destroy(gameObject);
		}
	}

}
