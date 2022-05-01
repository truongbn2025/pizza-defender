using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private float attackDelay;
    [SerializeField] private float speed;
    [SerializeField] private int dmg;
    [SerializeField] public int enemyType;
    [SerializeField] public float aggroDistance = 1f;
    [SerializeField] public float chasingDistance = 1f;
    float idleTime;





    [Tooltip("Material to switch to during the flash.")]
    [SerializeField] private Material flashMaterial;

    [Tooltip("Duration of the flash.")]
    [SerializeField] private float duration;


    // The SpriteRenderer that should flash.
    private SpriteRenderer spriteRenderer;

    // The material that was in use, when the script started.
    private Material originalMaterial;

    // The currently running coroutine.
    private Coroutine flashRoutine;



    Vector3 des;
    private IEnumerator coroutine;
    bool canAttack;
    int countDown;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // Get the SpriteRenderer to be used,
        // alternatively you could set it from the inspector.
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the material that the SpriteRenderer uses, 
        // so we can switch back to it after the flash ended.
        originalMaterial = spriteRenderer.material;
    }
    //SpriteRenderer sr;
    Animator animator;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        countDown = 300;
        canAttack = false;
        hp = 10;
        attackDelay = 4.0f;
        speed = 0.1f;
        dmg = 1;
        idleTime = 60;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        if (idleTime > 0)
        {
            idleTime--;
        }
        if (idleTime <= 0)
        {
            //Debug.Log("move");
            Movement(findWay(enemyType));
        }

        if (countDown > 0 && canAttack)
        {
            countDown--;
        }
        if (countDown == 0 && canAttack)
        {
            doDamage();

            countDown = 240;
        }



    }

    void timer(float time)
    {
        float timer = time;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            //Debug.Log(timer);
        }
        //Debug.Log("Go here");
        if (timer <= 0)
        {
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //Debug.Log("Collide with player");
            fallBack(gameObject.transform.position, collision.gameObject.transform.position, 1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.transform.tag == "NhaChinh")
        {

            canAttack = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.transform.tag == "NhaChinh")
        {

            canAttack = false;
        }

    }

    void doDamage()
    {
        BaseProperties.myBase.takeDamage(dmg);
        Debug.Log("do damage");
    }

    void Movement(Vector3 destination)
    {
        float step = speed * Time.deltaTime;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination, step);
    }
    Vector3 findWay(int enemyType)
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (enemyType == 2)
        {
            des = player.transform.position;
        }
        if (enemyType == 1)
        {
            des = BaseProperties.myBase.transform.position;
        }
        if (enemyType == 3)
        {
            //Debug.Log("Distance: " + distance);
            if ((float)distance <= (float)aggroDistance)
            {
                des = player.transform.position;


            }
            else
            {
                des = BaseProperties.myBase.transform.position;
            }

        }

        return des;
    }

    public void fallBack(Vector3 ammo, Vector3 target, int typeAmmo)
    {
        Debug.Log("fall back");
        Vector3 direction = target - ammo;
        float step = speed * Time.deltaTime;
        float fallDistance = 3f;

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, gameObject.transform.position - direction.normalized * fallDistance, speed);

    }
    public void getType(int type)
    {
        enemyType = type;
        Debug.Log(type);
    }
    void spawnIdle()
    {

    }


    public void Die()
    {
        if (hp <= 0)
        {
            animator.SetTrigger("isDeath");
            Destroy(gameObject, 0.15f);
        }
    }

    public void Flash()
    {
        // If the flashRoutine is not null, then it is currently running.
        if (flashRoutine != null)
        {
            // In this case, we should stop it first.
            // Multiple FlashRoutines the same time would cause bugs.
            StopCoroutine(flashRoutine);
        }

        // Start the Coroutine, and store the reference for it.
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        // Swap to the flashMaterial.
        spriteRenderer.material = flashMaterial;

        // Pause the execution of this function for "duration" seconds.
        yield return new WaitForSeconds(duration);

        // After the pause, swap back to the original material.
        spriteRenderer.material = originalMaterial;

        // Set the routine to null, signaling that it's finished.
        flashRoutine = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        //Die();
        if (collision.transform.tag == "PlayerBullet")
        {
            Flash();
            HealthDec();
            Destroy(collision.gameObject);
        }
        if(collision.transform.tag == "Player")
		{
            FindObjectOfType<GameSession>().LiveDec(dmg);
		}
        if (collision.transform.tag == "NhaChinh")
        {
            //FindObjectOfType<BaseProperties>().takeDamage(dmg);
        }
    }

    public void HealthDec()
	{
        int damage = FindObjectOfType<Projecttile>().GetDamage();
        hp -= damage;
	}

}
