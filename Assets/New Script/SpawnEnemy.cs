using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    //public SpawnEnemy Spawner;
    [SerializeField]private int spawnCountdown;
    public GameObject enemyTypeOne;
    public GameObject enemyTypeTwo;
    public GameObject enemyTypeThree;
    private int timeStep;
    private int enemyType;
    public bool stopSpawning;

    // Start is called before the first frame update
    void Start()
    {
        //Spawner = this;
        timeStep = 1;
        spawnCountdown = 500;
    }





    // Update is called once per frame
    void Update()
    {


        Debug.Log(this.name + " time step: " + timeStep);
        if (spawnCountdown > 0)
        {
            spawnCountdown -= timeStep;
            //Debug.Log(timeStep);
        }
        else
        {
            //Random
            enemyType = Random.Range(1, 4);


            if (enemyType == 1)
            {
                //Debug.Log("Spawn type: " + enemyType);
                GameObject newEnemy = Instantiate(enemyTypeOne, transform.position, Quaternion.identity);
                //newEnemy.SendMessage("getType", enemyType);
                spawnCountdown = 1000;

            }
            if (enemyType == 2)
            {
                //Debug.Log("Spawn type: " + enemyType);
                GameObject newEnemy = Instantiate(enemyTypeTwo, transform.position, Quaternion.identity);
                //newEnemy.SendMessage("getType", enemyType);
                spawnCountdown = 1000;

            }
            if (enemyType == 3)
            {
                //Debug.Log("Spawn type: " + enemyType);   
                GameObject newEnemy = Instantiate(enemyTypeThree, transform.position, Quaternion.identity);
                //newEnemy.SendMessage("getType", enemyType);
                spawnCountdown = 1000;
            }


        }

    }
    public void spawnSpeed(int speed)
    {
        timeStep = speed + 1;
    }
}
