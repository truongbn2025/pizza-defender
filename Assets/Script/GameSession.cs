using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives= 3;
    [SerializeField] int nhaChinhHealth = 100;

    [SerializeField] Text livesDisplay;
    [SerializeField] Text healthDisplay;

    

    // Start is called before the first frame update
    void Start()
    {
        livesDisplay.text = playerLives.ToString();
        healthDisplay.text = nhaChinhHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(playerLives <=0 || nhaChinhHealth <= 0)
		{
            Time.timeScale = 0;
		}
        */
    }


    public void LiveDec(int value)
	{
        playerLives -= value;
        livesDisplay.text = playerLives.ToString();
        if(playerLives <= 0)
		{
            SceneManager.LoadScene(4);
		}
	}

    public void HealthDec(int value)
    {
        nhaChinhHealth -= value;
        healthDisplay.text = nhaChinhHealth.ToString();
    }

    public int GetHealth()
	{
        return playerLives;
	}
}
