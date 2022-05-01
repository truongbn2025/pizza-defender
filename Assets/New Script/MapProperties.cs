using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProperties : MonoBehaviour
{
    public int asset;
    Vector3 sphereManualOnThisMap;
    public GameObject spawner;
    public int enemyBuff;
    public GameObject gun;
    public GameObject gun1;
    bool playerIsHere;
    private void Start()
    {
        enemyBuff = 0;
        gun.GetComponent<Gun>();
        gun1.GetComponent<Gun1>();
        SpawnEnemy spawner = gameObject.GetComponent<SpawnEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Player is here");
            playerIsHere = true;
        }
        if (collision.transform.tag == "Sphere")
            asset += 1;

        if (collision.transform.name == "ManualCircle")
        {
            sphereManualOnThisMap = collision.transform.position;
        }
        //spawner.SendMessage("spawnSpeed", asset);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Sphere")
            asset -= 1;
        if (collision.transform.tag == "Player")
        {

            playerIsHere = false;
        }
        //spawner.SendMessage("spawnSpeed", asset);
    }
    private void Update()
    {
        if (playerIsHere)
        {
            gun.GetComponent<Gun>().buff = asset;
            gun1.GetComponent<Gun1>().buff = asset;
        }
        if (asset == 2)
        {
            SphereAutoRotate.Instance.connect(sphereManualOnThisMap);

        }
        else
        {

            //Connection.Instance.isCalled(false);
            SphereAutoRotate.Instance.connect(new Vector3 (0,0,0));
        }

        gameObject.transform.tag = asset.ToString();
        //Debug.Log(asset);
    }
    
}
