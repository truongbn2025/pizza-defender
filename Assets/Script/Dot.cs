using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    [SerializeField] Transform dot;
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myBody;
    Vector3 mousePos;
    Vector2 positon = new Vector2(0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positon = Vector2.Lerp(transform.position, mousePos, moveSpeed);
    }

	private void FixedUpdate()
	{
        myBody.MovePosition(positon);
	}
}
