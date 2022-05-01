using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform dot;
    [SerializeField] float baseSpeed = 1f;
    [SerializeField] int offset = -180;
    [SerializeField] float baseFireRate = 15f;
    [SerializeField] int maxAmmo = 30;
    [SerializeField] float baseReloadTime = 1f;
    [SerializeField] AudioClip shootSFX;
    [SerializeField] float volume = 1f;

    [SerializeField] float speed;
    [SerializeField] float fireRate;
    [SerializeField] float reloadTime;

    public int buff;
    public Gun1 Instance;

    Coroutine firingCoroutine;
    private bool FacingRight = true;
    private int currentAmmo;
    private bool isReload = false;
    private float nextTimeToFire = 0f;
    Animator animator;
    private void Start()
    {
        //Instance = this;
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
        Debug.Log("buff= " + buff);

        buffStat(buff);

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
            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, volume);
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

    private float AngleBetweenTwoPoint(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void Fire()
    {
        currentAmmo--;
        animator.SetBool("isShoot", true);
        GameObject projectile = Instantiate(bullet, firePoint.transform.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up, ForceMode2D.Impulse);
    }


    /*
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinously()
	{
		while (true)
		{
            currentAmmo--;
            GameObject projectile = Instantiate(bullet, firePoint.transform.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up, ForceMode2D.Impulse);
            yield return new WaitForSeconds(shotPerSec);
        }
	}
   */

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



    void buffStat(int levelBuff)
    {
        speed = baseSpeed * (buff + 1);
        reloadTime = baseReloadTime * 3 / 4;
        fireRate = baseFireRate * (buff + 1);
    }
}
