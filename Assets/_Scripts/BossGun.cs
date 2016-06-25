using UnityEngine;
using System.Collections;

public class BossGun : MonoBehaviour {

  public GameObject LaserPrefab;
  public float startDelay = 1f;
  public float fireRate = 0.2f;
  public float burstRate = 6f;
  public float burstLength = 3;

  private Transform target;

	void Start ()
  {
    StartCoroutine (PewPewPew());
	}

  void Aim()
  {
    transform.rotation = Quaternion.Euler(0, 0, Random.Range(70, 110));
  }

  IEnumerator PewPewPew ()
  {
    yield return new WaitForSeconds (startDelay);
    while (true)
    {
      for (int i = 0; i < burstLength; i++)
      {
        Aim();
        Instantiate(LaserPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds (fireRate);
      }
      yield return new WaitForSeconds (burstRate);
    }
  }

}
