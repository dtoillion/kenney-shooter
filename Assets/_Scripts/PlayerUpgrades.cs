using UnityEngine;
using System.Collections;

public class PlayerUpgrades : MonoBehaviour {

  public GameObject Cockpit;
  public GameObject Engine;
  public GameObject Gun;
  public GameObject Turret;
  public GameObject TurretTwo;
  AudioSource UpgradeNoiseAudio;
  public AudioClip UpgradeNoise;

	void Start()
  {
    UpgradeNoiseAudio = GetComponent<AudioSource>();
  }

  void Update ()
  {

	}
}
