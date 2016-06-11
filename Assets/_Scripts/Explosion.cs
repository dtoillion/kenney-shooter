using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float Lifetime = 0.5f;

	void Start () {
		Destroy(gameObject, Lifetime);
	}
}
