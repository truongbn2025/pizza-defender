using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float offset = 1f;
    [SerializeField] int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 projectileVelocity = new Vector2(projectileSpeed * Time.deltaTime, 0f);
        transform.Translate(projectileVelocity);
    }


	/*private void OnTriggerEnter2D(Collider2D other)
	{
        Destroy(gameObject);
        other.GetComponent<SpriteRenderer>().color = Color.red;
    }*/


    public int GetDamage()
	{
        return damage;
	}
}
