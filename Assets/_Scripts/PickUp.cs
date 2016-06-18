using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

  public GameObject EffectPrefab;
  public bool Health = true;
  public bool Speed = false;
  public bool RedFireSpeed = false;
  public bool BlueFireSpeed = false;
  public bool GreenFireSpeed = false;

	void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.tag == "Player")
		{
      if(Health)
			  GameControl.control.health += 10f;
      if(Speed)
        GameControl.control.Speed += 5f;
      if(RedFireSpeed)
        GameControl.control.fireRateRed -= .01f;
      if(BlueFireSpeed)
        GameControl.control.fireRateBlue -= .01f;
      if(GreenFireSpeed)
        GameControl.control.fireRateGreen -= .01f;

      GameControl.control.score += 10f;
      Instantiate(EffectPrefab, transform.position, transform.rotation);
      EffectPrefab.transform.parent = null;
			Destroy(gameObject);

		}
	}

}
