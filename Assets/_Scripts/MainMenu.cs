using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    void Update() {
    	if(Input.GetKeyDown("escape")) {
        	Application.Quit();
        }
        else if(Input.anyKeyDown) {
        	SceneManager.LoadScene("Level001");
        }
    }
}