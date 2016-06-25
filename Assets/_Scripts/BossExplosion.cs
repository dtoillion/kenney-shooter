using UnityEngine;
using System.Collections;

public class BossExplosion : MonoBehaviour {

	void Start ()
  {
    Invoke("Death", 1f);
	}

  private void Death()
  {
    GameControl.control.CheckBoss();
  }

}
