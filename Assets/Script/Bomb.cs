using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float radius = 5f;
    [SerializeField] float force;

    public LayerMask layerToHit;


    EnemyProperties ep;

    // Start is called before the first frame update
    void Start()
    {
        ep = FindObjectOfType<EnemyProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
	{
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layerToHit);
        foreach(Collider2D obj in colliders)
		{
            Vector2 dir = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(dir * force);
            
		}
        Destroy(gameObject);
	}

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
	}
}
