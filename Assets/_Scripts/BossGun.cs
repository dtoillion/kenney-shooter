using UnityEngine;
using System.Collections;

public class BossGun : MonoBehaviour {

  public GameObject LaserPrefab;
  public float startDelay = 1f;
  public float fireRate = 0.2f;
  public float burstRate = 6f;
  public float burstLength = 3;
  public float turretSpeed = 3;
  public Transform target;

	void Start ()
  {
    StartCoroutine (PewPewPew());
	}

  void Update()
  {
    Aim();
  }

  void Aim() {
    if(GameObject.FindWithTag("Player"))
    {
      target = GameObject.FindWithTag("Player").transform;
      Vector3 vectorToTarget = target.position - transform.position;
      float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 90;
      Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
      transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turretSpeed);
    }
  }

  IEnumerator PewPewPew ()
  {
    yield return new WaitForSeconds (startDelay);
    while (true)
    {
      for (int i = 0; i < burstLength; i++)
      {
        Instantiate(LaserPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds (fireRate);
      }
      yield return new WaitForSeconds (burstRate);
    }
  }

}
