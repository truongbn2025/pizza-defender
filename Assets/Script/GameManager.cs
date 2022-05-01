using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerMovement Player;
    public GameObject Map;
    private void Start()
    {
        MapProperties[] Maps = Map.GetComponentsInChildren<MapProperties>();
        foreach(MapProperties Piece in Maps)
        {
            Debug.Log("map: " + Piece.transform.name);
        }
    }
    private void Update()
    {
        
    }
}
