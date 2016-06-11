using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	
    public void Quit ()
    {
    	Application.Quit();
    }
    public void Retry ()
    {
        SceneManager.LoadScene("Level001");
    }
}
