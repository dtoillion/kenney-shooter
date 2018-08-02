using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouser : MonoBehaviour {

  void Update ()
  {
    RotateToMouse ();
  }

  void RotateToMouse () {
   var mouse = Input.mousePosition;
   var screenPoint = Camera.main.WorldToScreenPoint(transform.position);
   var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
   var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg - 90;
   transform.rotation = Quaternion.Euler(0, 0, angle);
  }
}
