using UnityEngine;

// Rotate rigidBody2D every frame.  Start at 45 degrees.

public class SphereRotateManual : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        checkPress();
    }

    private void checkPress()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            rigidBody2D.rotation += 120.0f;
        if (Input.GetKeyDown(KeyCode.E))
            rigidBody2D.rotation -= 120.0f;
    }

}