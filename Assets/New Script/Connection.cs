using UnityEngine;
using System.Collections;

public class Connection : MonoBehaviour
{
    [SerializeField] public Vector3 startPosition = new Vector3(0f, 0f, 0f);
    [SerializeField] public Vector3 endPosition = new Vector3(5f, 1f, 0f);
    public bool mirrorZ = true;
    public static Connection Instance;
    private bool isCall;

    void Start()
    {
        isCall = true;
        Instance = this;
    }

    private void Update()
    {

    }

    public void isCalled(Vector3 startPos, Vector3 endPos)
    {
        //Debug.Log("is called");
        isCall = true;
        startPosition = startPos;
        endPosition = endPos;
        gameObject.GetComponent<Renderer>().enabled = true;
        Strech(gameObject, startPosition, endPosition, mirrorZ);

    }

    public void isCalled(bool call)
    {
        if (call == false)
        {
            //Debug.Log("Set False");
            gameObject.GetComponent<Renderer>().enabled = false;
        }

    }


    public void Strech(GameObject _sprite, Vector3 _initialPosition, Vector3 _finalPosition, bool _mirrorZ)
    {
        //Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
        _sprite.transform.position = (_initialPosition + _finalPosition) / 2;
        Vector3 direction = _finalPosition - _initialPosition;
        direction = Vector3.Normalize(direction);
        _sprite.transform.right = direction;
        if (_mirrorZ) _sprite.transform.right *= -1f;
        Vector3 scale = this.transform.localScale;
        scale.x = Vector3.Distance(_initialPosition, _finalPosition) / 4;
        _sprite.transform.localScale = scale;
    }
}