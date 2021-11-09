using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuile : MonoBehaviour
{
    private string id;
    private Vector2 position;
    private string type;
    private bool floor;
    private bool passable;


    public void Create(float i, float j)
    {
        transform.position = new Vector3(i, 0, j);
        position = new Vector2(i, j);
        type = "Ground";
        floor = true;
        passable = true;
        id = type + "f : " + floor + " p : "+passable+ " pos : " + position;
    }

    public bool isFloorPassable()
    {
        if(floor && passable)
        {
            return true;
        }
        return false;
    }

    public string ID()
    {
        return id;
    }

    
}
