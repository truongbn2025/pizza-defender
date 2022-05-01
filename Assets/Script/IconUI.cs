using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconUI : MonoBehaviour
{
    public void OnMouseDown()
	{
        var icons = FindObjectsOfType<IconUI>();
        foreach(IconUI icon in icons)
		{
            icon.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
		}

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeCollor();
    }
}
