using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private Vector2 boardPosition;
    private Vector2 targetBoardPosition;
    private Vector3 targetWorldPosition;

    private Vector3 moveDelta;
    private float speed = 5;
    private bool isPassable = false;

    //Update
    private void FixedUpdate()
    {
        if (targetWorldPosition != transform.position)
        {
            
            transform.Translate(moveDelta * speed * Time.deltaTime);
        }
       
    }

    //Getter and Setter
    public void setAllPosition(Vector3 p)
    {
        transform.position = new Vector3(p.x,0.3f,p.y) ;
        targetWorldPosition = new Vector3(p.x, 0.3f, p.y);
        boardPosition = new Vector2(p.x,p.y);
        targetBoardPosition = new Vector2(p.x, p.y);
    }
    public bool IsPassable()
    {
        if (isPassable)
        {
            return true;
        }
        return false;
    }
    public Vector2 getBoardPosition()
    {
        return boardPosition;
    }
    public void setBoardPosition(Vector2 v)
    {
        boardPosition = v;
    }
    public Vector2 getTargetBoardPosition()
    {
        return targetBoardPosition;
    }
    public void setTargetBoardPosition(Vector2 v)
    {
        targetBoardPosition = v;
    }
    public Vector3 getTargetWorldPosition()
    {
        return targetWorldPosition;
    }
    public void setTargetWorldPosition(Vector3 v)
    {
        targetWorldPosition = v;
    }
    public Vector3 getMoveDelta()
    {
        return moveDelta;
    }
    public void setMoveDelta(Vector3 v)
    {
        moveDelta = v;
    }
    public void setSpeed(float f)
    {
        speed = f;
    }
    public float getSpeed()
    {
        return speed;
    }
}
