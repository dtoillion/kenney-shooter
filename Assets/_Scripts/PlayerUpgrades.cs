using UnityEngine;
using System.Collections;

public class PlayerUpgrades : MonoBehaviour {

  public static PlayerUpgrades control;

  public GameObject Cockpit;
  public GameObject Engine;
  public GameObject Gun;
  public GameObject Turret;
  public GameObject TurretTwo;
  public AudioClip UpgradeNoise;

  AudioSource UpgradeNoiseAudio;

  void Awake ()
  {
    control = this;
  }

  void Start()
  {
    UpgradeNoiseAudio = GetComponent<AudioSource>();
  }

  void PlayNoise()
  {
    UpgradeNoiseAudio.PlayOneShot(UpgradeNoise, 1f);
  }

  public void UnlockGuns ()
  {
    if(GameControl.control.score >= 5000)
    {
      Gun.SetActive(true);
      PlayNoise();
    }
	}
}
