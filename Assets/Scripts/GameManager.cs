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
        inputActions.Basic.Move.performed += PlayerMove;
        inputActions.Basic.Move.Enable();
    }
    private void OnDisable()
    {
        inputActions.Basic.Move.Disable();

    }

    private void PlayerMove(InputAction.CallbackContext obj)
    {
        if (player.getTargetWorldPosition() == player.transform.position)
        {
            Debug.Log("LOG");
            Vector2 pMove = inputActions.Basic.Move.ReadValue<Vector2>();
            MoveOrder(player, pMove);

            /*
            Vector2 nMove = RandomOrtho();
            MoveOrder(npc, nMove);
            ShowText("hello", 25, Color.red, player.transform.position + new Vector3(0, .5f, 0), Vector3.up * 50, .3f);
            */
           
        }
    }
    private void MoveOrder(Entity e, Vector2 move)
    {
        e.setTargetBoardPosition(new Vector2(Mathf.Round(move.x), Mathf.Round(move.y)) + e.getBoardPosition());

        Debug.Log(e + " to " + e.getBoardPosition() + " -> " + e.getTargetBoardPosition());

        if (IsPassable(e))
        {
            e.setMoveDelta(new Vector3(Mathf.Round(move.x), 0, Mathf.Round(move.y)));
            e.setTargetWorldPosition(new Vector3(Mathf.Round(move.x), 0, Mathf.Round(move.y)) + e.transform.position);
            e.setBoardPosition(e.getTargetBoardPosition());
        }
        
    }
    private bool IsPassable(Entity e)
    {
        if (isFloorPassable(e.getTargetBoardPosition()))
        {

            foreach (Entity ye in entitiesList)
            {
                if (ye.getBoardPosition() == e.getTargetBoardPosition())
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
