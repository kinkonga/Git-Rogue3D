using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector2 mapSize;
    [SerializeField] private GameObject tuile;
    [SerializeField] private GameObject player;

    //reference
    private PlayerAction inputActions;
    private GameObject[,] mapArray;

    private void Awake()
    {
        //instanciate Reference
        inputActions = new PlayerAction();
        mapArray = new GameObject[(int)mapSize.x, (int)mapSize.y];

        DrawMap();
    }

    private void DrawMap()
    {
        for (int i = 0; mapSize.x > i; i++)
        {
            for (int j = 0; mapSize.y > j; j++)
            {
                mapArray[i, j] = Instantiate(tuile) as GameObject;
                mapArray[i, j].GetComponent<Tuile>().Create(i, j);
                Debug.Log(mapArray[i, j].GetComponent<Tuile>().ID());
            }
        }
    }
}
