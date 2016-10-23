using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GlobalButtonActions : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Load Current Level
    public void loadCurrentLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    // Load Level
    public void loadLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
    }

    // Quit Application
    public void quitApplication()
    {
        Application.Quit();
    }
}
