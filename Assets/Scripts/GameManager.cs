using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //SERIALIZE
    [SerializeField] private Vector2 mapSize;
    [SerializeField] private GameObject tuile;
    [SerializeField] private Player player;

    private List<Entity> entitiesList;

    //REFERENCE
    private PlayerAction inputActions;
    private GameObject[,] mapArray;

    private void Awake()
    {
        //instanciate Reference
        inputActions = new PlayerAction();
        mapArray = new GameObject[(int)mapSize.x, (int)mapSize.y];
        entitiesList = new List<Entity>();

        player = Instantiate(player);
        entitiesList.Add(player);
        player.setAllPosition(new Vector3(0, 0, 0));

        DrawMap();
    }
    private void OnEnable()
    {
        //INPUT
        inputActions.Basic.Move.performed += moveFront;
        inputActions.Basic.Move.Enable();
        inputActions.Basic.Rotate.performed += PlayerRotate;
        inputActions.Basic.Rotate.Enable();
    }
    private void OnDisable()
    {
        inputActions.Basic.Move.Disable();
        inputActions.Basic.Rotate.Disable();

    }

    private void PlayerMove(InputAction.CallbackContext obj)
    {
        if (player.TargetWorldPosition == player.transform.position)
        {
            Debug.Log("LOG");
            Vector2 pMove = inputActions.Basic.Move.ReadValue<Vector2>();
            MoveOrder(player, pMove);

        }
    }


    private void PlayerRotate(InputAction.CallbackContext obj)
    {
        float pRotate = inputActions.Basic.Rotate.ReadValue<float>();
        pRotate *= 90;
        Debug.Log("input : " +pRotate);
        Quaternion q = Quaternion.Euler(0, pRotate, 0);
        player.TargetRotation = q * player.transform.rotation;
        Debug.Log("player target " + player.TargetRotation);
        player.RotateDelta = new Vector3(0, pRotate, 0);
    }

    private void moveFront(InputAction.CallbackContext obj)
    {
        Debug.Log(inputActions.Basic.Move.ReadValue<Vector2>());
    }

    private void MoveOrder(Entity e, Vector2 move)
    {
        e.TargetBoardPosition = new Vector2(Mathf.Round(move.x), Mathf.Round(move.y)) + e.BoardPosition;

        Debug.Log(e + " to " + e.BoardPosition + " -> " + e.TargetBoardPosition);

        if (IsPassable(e))
        {
            e.MoveDelta = new Vector3(Mathf.Round(move.x), 0, Mathf.Round(move.y));
            e.TargetWorldPosition = new Vector3(Mathf.Round(move.x), 0, Mathf.Round(move.y)) + e.transform.position;
            e.BoardPosition = e.TargetBoardPosition;
        }
        
    }
    private bool IsPassable(Entity e)
    {
        if (isFloorPassable(e.TargetBoardPosition))
        {

            foreach (Entity ye in entitiesList)
            {
                if (ye.BoardPosition == e.TargetBoardPosition)
                {
                    return false;
                }
            }
            return true;

        }
        return false;
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
    private bool isFloorPassable(Vector2 pos)
    {
        if (pos.x > mapSize.x - 1 || pos.y > mapSize.y - 1 || pos.x < 0 || pos.y < 0)
        {
            return false;
        }
        if (mapArray[(int)pos.x, (int)pos.y].GetComponent<Tuile>().isFloorPassable())
        {
            return true;
        }
        return false;
    }
}
