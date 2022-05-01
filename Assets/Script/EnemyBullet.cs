using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] int damage = 1;

    Rigidbody2D rb;
    PlayerMovement player;
    Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<PlayerMovement>();
        moveDir = (player.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(gameObject, 4f);
    }

	private void Update()
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name.Equals("Player"))
		{
            FindObjectOfType<GameSession>().LiveDec(damage);
            Destroy(gameObject);
		}
	}
}
