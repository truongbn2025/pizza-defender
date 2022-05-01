using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScrpit : MonoBehaviour
{
    int currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
	{
        SceneManager.LoadScene(currentScene + 1);
	}

    public void QuitGame()
	{
        Application.Quit();
	}

    public void Credit()
	{
        SceneManager.LoadScene(2);
	}

    public void MenuScene()
	{
        SceneManager.LoadScene(0);
	}
}
