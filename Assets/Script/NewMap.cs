using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMap : MonoBehaviour
{
    int sphere;
    SpriteRenderer sprite;
    Vector3 sphereManualOnThisMap;
    // Start is called before the first frame update

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Sphere")
        {
            sphere += 1;
            //FindObjectOfType<PlayerMovement>().SetBuff(); 
        }

        if (collision.transform.name == "ManualCircle")
        {
            sphereManualOnThisMap = collision.transform.position;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Sphere")
            sphere -= 1;

    }
    private void Update()

    {
        Debug.Log(gameObject.transform.name + ": " + sphere);
        if (sphere == 2)
        {
            SphereAutoRotate.Instance.connect(sphereManualOnThisMap);

        }
        else
        {

            //Connection.Instance.isCalled(false);
            //SphereAutoRotate.Instance.connect(new Vector3 (0,0,0));
        }
    }
}
