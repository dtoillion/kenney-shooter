using UnityEngine;
using System.Collections;

public class PlayerProgression : MonoBehaviour {

  public GameObject UpgradeOne;
  public GameObject UpgradeTwo;

	void Update ()
  {
    if(GameControl.control.score >= 500)
      UpgradeOne.SetActive(true);
    if(GameControl.control.score >= 1000)
      UpgradeTwo.SetActive(true);
	}

}
