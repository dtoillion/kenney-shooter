using UnityEngine;
using System.Collections;

public class DestroyOnTouch : MonoBehaviour {

  public bool laserTrap = false;
  public bool destroyAll = true;

	void OnTriggerEnter2D(Collider2D trig)
	{
    if(destroyAll)
      Destroy(trig.gameObject, 0);
    if((laserTrap) && (trig.gameObject.tag == "Projectile"))
      Destroy(trig.gameObject, 0);
  }

}
