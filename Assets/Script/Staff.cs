using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform dot;
    [SerializeField] float speed = 1f;
    [SerializeField] int offset = -180;
    [SerializeField] float fireRate = 15f;
    [SerializeField] int maxAmmo = 30;
    [SerializeField] float reloadTime = 1f;

    private bool FacingRight = true;
    private int currentAmmo;
    private bool isReload = false;
    private float nextTimeToFire = 0f;
    Animator animator;


    private void Start()
    {
        currentAmmo = maxAmmo;
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        isReload = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        FlipGun();
        if (isReload == true) { return; }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("isShoot", false);
        }
    }

    IEnumerator Reload()
    {
        isReload = true;
        animator.SetBool("isShoot", false);
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReload = false;
    }

    private void RotateGun()
    {
        var dir = dot.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - offset;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    private void Fire()
    {
        currentAmmo--;
        //animator.SetBool("isShoot", true);
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        Instantiate(bullet, objectPos, Quaternion.identity);
    }


    private void Flip()
    {
        Vector3 tmpScale = transform.localScale;
        tmpScale.y = -tmpScale.y;
        transform.localScale = tmpScale;
        FacingRight = !FacingRight;
    }

    private void FlipGun()
    {
        if (dot.position.x < transform.position.x && FacingRight)
        {
            Flip();
        }
        else if (dot.position.x > transform.position.x && !FacingRight)
        {
            Flip();
        }
    }
}
