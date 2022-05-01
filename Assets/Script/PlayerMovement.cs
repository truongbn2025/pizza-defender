using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 1f;
    [SerializeField] Transform dot;
    [SerializeField] float dashSpeed = 1f;
    [SerializeField] float dashTime = 0.5f;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    bool FacingRight = true;
    int buff;
    public bool changeBuff;

    Rigidbody2D myBody;
    Animator animator;
    Coroutine Dashing;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
         horizontal = Input.GetAxis("Horizontal");
         vertical = Input.GetAxis("Vertical");
    }


	private void FixedUpdate()
	{
        if (changeBuff)
        {
            RecieveBuff(buff);
        }
        
        Move();
        FlipWhenIdle();
        FlipWhenRun();
        if(Input.GetKeyDown(KeyCode.LeftControl) && Dashing == null)
		{
            Dashing = StartCoroutine(DashCoroutine());
		}
	}

	private void Move()
	{
		if (horizontal != 0 && vertical != 0)
		{
			horizontal *= moveLimiter;
			vertical *= moveLimiter;
		}

		myBody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        bool hasRun = Mathf.Abs(myBody.velocity.x) > Mathf.Epsilon || Mathf.Abs(myBody.velocity.y) > Mathf.Epsilon;
  
            animator.SetBool("isMove", hasRun);
	}

    private void FlipWhenIdle()
	{
        if (dot.position.x < transform.position.x && FacingRight)
        {
            animator.SetBool("ChangeLook", false);
            FacingRight = !FacingRight;
        }
        else if (dot.position.x > transform.position.x && !FacingRight)
        {
            animator.SetBool("ChangeLook", true);
            FacingRight = !FacingRight;
        }
    }

    private void FlipWhenRun()
    {
        if (dot.position.x < transform.position.x && FacingRight)
        {
            animator.SetBool("isMove", false);
            FacingRight = !FacingRight;
        }
        else if (dot.position.x > transform.position.x && !FacingRight)
        {
            animator.SetBool("isMove", true);
            FacingRight = !FacingRight;
        }
    }


    private IEnumerator DashCoroutine()
	{
        var endoffFrame = new WaitForEndOfFrame();
        var rigidbody = GetComponent<Rigidbody2D>();
        
        for( float timer = 0; timer < dashTime; timer += Time.deltaTime)
		{
            rigidbody.MovePosition(transform.position + (transform.forward * (dashSpeed * Time.deltaTime)));
            yield return endoffFrame;
		}
        Dashing = null;
	}

   

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.transform.tag == "2")
		{
            buff = 2;
		}
        if (other.gameObject.transform.tag == "1")
        {
            buff = 1;
        }
        if (other.gameObject.transform.tag == "0")
        {
            buff = 0;
        }
    }

	private void RecieveBuff(int buff)
	{
        runSpeed = runSpeed * (buff + 1);
        Debug.Log("buff received: "+ buff);
    }
     
    public void ChangeBuff(int newBuff)
    {
        buff = newBuff;
    }
}
