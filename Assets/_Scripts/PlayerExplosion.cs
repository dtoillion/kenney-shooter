using UnityEngine;
using System.Collections;

public class PlayerExplosion : MonoBehaviour {

	void Start ()
  {
    Invoke("Death", 1f);
	}

  private void Death()
  {
    GameControl.control.GameOver();
  }

}
