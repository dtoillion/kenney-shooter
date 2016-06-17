using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			GameControl.control.health+=10f;
			Destroy(gameObject);
		}
	}

}
