using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

  public GameObject EffectPrefab;

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
