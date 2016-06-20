using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelControl : MonoBehaviour {

  public Text Notification;

  private float CurrentLevel = 1;


  void Start ()
  {
    CheckLevel();
  }

  void Update ()
  {

  }

  void CheckLevel ()
  {
    Notification.text = ("Level " + CurrentLevel);
  }

}
