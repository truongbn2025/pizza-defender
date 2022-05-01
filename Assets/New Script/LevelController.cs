using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    GameObject[] gameObjects;

    private float waveTime;
    private float timeLeft;

    private int waveNumber;
    private int waveCount;

    public Text txt;
    private void Start()
    {
        txt.GetComponent<UnityEngine.UI.Text>();
        waveTime = 60;
        timeLeft = waveTime;
        waveCount = 0;
        waveNumber = 5;
    }
    void Update()
    {
        Win();
        //Debug.Log(timeLeft);
        timeLeft -= Time.deltaTime;
        string s = ((int)timeLeft / 60).ToString() + ":" + ((int)timeLeft % 60);

        txt.text = s;

        if (timeLeft <= 0 && waveCount <= waveNumber)
        {
            nextWave();
        }

    }

    void nextWave()
    {
        timeLeft = waveTime;
        waveCount++;
        Debug.Log(waveCount);
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);
        //Debug.Log("next Wave");
    }


    void Win()
	{
        if(waveCount >= 1)
		{
            SceneManager.LoadScene(3);
		}
	}
}
