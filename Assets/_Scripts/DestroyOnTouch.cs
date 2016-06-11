using UnityEngine;
using System.Collections;

public class DestroyOnTouch : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D trig)
	{
        Destroy(trig.gameObject, 0);
    }
}
