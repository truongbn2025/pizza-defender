using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] float attackRange;
    [SerializeField] float fireRate;
    [SerializeField] float bulletForce;
    [SerializeField] float chaseRange;
    [SerializeField] float speed;
    [SerializeField] Transform player;
    [SerializeField] GameObject projectile;

    private float lastAttackTime;
    private float distanceToTarget;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (distanceToTarget < chaseRange)
        {
            Chase(player.position);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, player.position);

        if (distanceToTarget < attackRange)
        {
            if (Time.time > lastAttackTime + fireRate)
            {
                RaycastHit2D Hit = Physics2D.Raycast(transform.position, transform.up, attackRange, 1 << LayerMask.NameToLayer("Player"));
                if (Hit)
                {
                    Fire();
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    private void Chase(Vector3 target)
    {
        Vector3 targetDir = target - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
        rb.velocity = targetDir.normalized * speed;
    }

    private void Fire()
    {
        GameObject newBullet = Instantiate(projectile, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
    }
}
