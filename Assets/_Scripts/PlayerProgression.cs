using UnityEngine;
using System.Collections;

public class PlayerProgression : MonoBehaviour {

  public GameObject UpgradeOne;
  public GameObject UpgradeTwo;

	void Update ()
  {
    if(GameControl.control.score >= 5000)
      UpgradeOne.SetActive(true);
    if(GameControl.control.score >= 10000)
      UpgradeTwo.SetActive(true);
	}

}
