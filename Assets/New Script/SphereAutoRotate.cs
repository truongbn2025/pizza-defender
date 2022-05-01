using UnityEngine;

// Rotate rigidBody2D every frame.  Start at 45 degrees.

public class SphereAutoRotate : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public bool mirrorZ = true;
    public GameObject circle;
    private LineRenderer line;
    public Rigidbody2D rigidBody2D;
    public static SphereAutoRotate Instance;
    void Start()
    {
        //line = this.gameObject.AddComponent<LineRenderer>();
        circle = GetComponent<GameObject>();
        //Strech(circle, startPosition, endPosition, mirrorZ);
        /*
        line.SetVertexCount(2);
        line.sortingOrder = 1;
        
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.rotation = 45f;
        */
        Instance = this;
    }

    void Update()
    {
        rigidBody2D.rotation += 0.2f;
    }

    public void connect(Vector3 des)
    {
        //Connection.Instance.isCalled(transform.GetChild(0).position, des);
        /*
        if(des != new Vector3(0, 0, 0))
        {
            line.SetPosition(0, transform.GetChild(0).position + new Vector3(0, 0, -1));
            line.SetPosition(1, des + new Vector3(0, 0, -1));
        }
       */

    }

    /*
    public void Strech(GameObject sprite, Vector3 _initialPosition, Vector3 _finalPosition, bool _mirrorZ)
    {
        Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
        sprite.transform.position = centerPos;
        Vector3 direction = _finalPosition - _initialPosition;
        direction = Vector3.Normalize(direction);
        sprite.transform.right = direction;
        if (_mirrorZ) sprite.transform.right *= -1f;
        Vector3 scale = new Vector3(1, 1, 1);
        scale.x = Vector3.Distance(_initialPosition, _finalPosition);
        sprite.transform.localScale = scale;
    }
    */


}