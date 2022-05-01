using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    float fireRate = 10f;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeToFire();
    }

    private void CheckTimeToFire()
	{
        if(Time.time > nextFire)
		{
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
		}
	}
}
