using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private Vector2 boardPosition;
    private Vector2 targetBoardPosition;
    private Vector3 targetWorldPosition;
    private Quaternion targetRotation;

    private Vector3 moveDelta;
    private Vector3 rotateDelta;
    private float speed = 5;
    private bool isPassable = false;

    //Update
    private void FixedUpdate()
    {
        if (targetWorldPosition != transform.position)
        {
            
            transform.Translate(moveDelta * speed * Time.deltaTime);
            
        }

        if (targetRotation != transform.rotation)
        {
            transform.Rotate(rotateDelta * Time.deltaTime);
        }

       
    }

    //Getter and Setter
    public void setAllPosition(Vector3 p)
    {
        transform.position = new Vector3(p.x, 0.48f, p.y) ;
        targetWorldPosition = new Vector3(p.x, 0.48f, p.y);
        boardPosition = new Vector2(p.x,p.y);
        targetBoardPosition = new Vector2(p.x, p.y);
        targetRotation = transform.rotation;
    }
    public bool IsPassable()
    {
        if (isPassable)
        {
            return true;
        }
        return false;
    }
    /*
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
    */
    public float Speed { get => speed; set => speed = value; }
    public Vector2 BoardPosition { get => boardPosition; set => boardPosition = value; }
    public Vector2 TargetBoardPosition { get => targetBoardPosition; set => targetBoardPosition = value; }
    public Vector3 TargetWorldPosition { get => targetWorldPosition; set => targetWorldPosition = value; }
    public Quaternion TargetRotation { get => targetRotation; set => targetRotation = value; }
    public Vector3 MoveDelta { get => moveDelta; set => moveDelta = value; }
    public Vector3 RotateDelta { get => rotateDelta; set => rotateDelta = value; }
    /*
    public void setTargetRotation(Quaternion rotation)
    {
        targetRotation = rotation;
    }
    public Quaternion getTargetRotation()
    {
        return targetRotation;
    }
    public void setRotationDelta(Vector3 eulers)
    {
        rotateDelta = eulers;
    }
    public Vector3 getRotationDelta()
    {
        return rotateDelta;
    }*/
}
