using UnityEngine;
using System.Collections;

public class WaveMachine : MonoBehaviour {

	public GameObject[] enemies;
	public GameObject[] bosses;
	public float spawnRate = 5f;
	public float startDelay = 3f;
	public float timeBetweenWaves = 3f;
	public float minX = 0f;
	public float maxX = 0f;
	public float minY = 0f;
	public float maxY = 0f;
	public float minZ = 0f;
	public float maxZ = 0f;
	public AudioClip LevelPass;
	private Vector3 originPosition;
	AudioSource waveAudio;

	void Start ()
	{
		waveAudio = GetComponent<AudioSource>();
		originPosition = new Vector3((Random.Range(minX, maxX)), (Random.Range(minY, maxY)), (Random.Range(minZ, maxZ)));
		StartCoroutine (Spawn());
	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds (startDelay);
		while (true)
		{
			for (int i = 0; i < (Random.Range((GameControl.control.CurrentLevel * 2), (GameControl.control.CurrentLevel * 3))); i++)
			{
				originPosition = new Vector3((Random.Range(minX, maxX)), (Random.Range(minY, maxY)), (Random.Range(minZ, maxZ)));
				Instantiate(enemies[Random.Range(0, enemies.Length)], originPosition, transform.rotation);
				yield return new WaitForSeconds (spawnRate);
			}
			yield return new WaitForSeconds (timeBetweenWaves);
			if(GameControl.control.CurrentLevel >= 3)
			{
				for (int i = 0; i < GameControl.control.CurrentLevel - 2; i++)
				{
					GameControl.control.BossPresent = true;
					originPosition = new Vector3((Random.Range(minX, maxX)), (Random.Range(minY, maxY)), (Random.Range(minZ, maxZ)));
					Instantiate(bosses[Random.Range(0, bosses.Length)], originPosition, transform.rotation);
					yield return new WaitForSeconds (spawnRate * 2);
				}
			}
			while (GameControl.control.BossPresent)
			{
				yield return null;
			}
			GameControl.control.CurrentLevel += 1;
			waveAudio.PlayOneShot(LevelPass, 1f);
			yield return new WaitForSeconds (5);
		}
	}

}
