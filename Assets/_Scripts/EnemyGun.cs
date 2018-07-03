using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {

  public GameObject[] LaserPrefabs;
  public GameObject LaserPrefab;
  public float fireRate = 0.2f;
  public float burstRate = 6f;
  public float burstLength = 3;

  void Start ()
  {
    SetupEnemyGun();
    StartCoroutine (PewPewPew());
  }

  void SetupEnemyGun() {
    LaserPrefab = LaserPrefabs[Random.Range(0, LaserPrefabs.Length)];
  }

  IEnumerator PewPewPew ()
  {
    yield return new WaitForSeconds (5);
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
