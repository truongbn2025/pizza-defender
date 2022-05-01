using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseProperties : MonoBehaviour
{
    public static BaseProperties myBase;
    [SerializeField] Text baseHealth;

    [SerializeField] private float hp;
    void Start()
    {
        myBase = this;
        hp = 100;
        baseHealth.text = hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(float damage)
    {
        hp -= damage;
        baseHealth.text = hp.ToString();
        Debug.Log("hp: " + hp);

    }
}
