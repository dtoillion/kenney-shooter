using UnityEngine;
using System.Collections;

public class CameraSize : MonoBehaviour
{
  public float SpriteSize;

  void Awake()
  {
    this.gameObject.GetComponent<Camera>().orthographicSize = (Screen.height / SpriteSize / 2.0f);
  }
}
