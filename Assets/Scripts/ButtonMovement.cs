using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    private GameObject pointer;
    private Vector3 addToPos;
    private bool hasAdded;
    private int debugTestNum = 0;

    public void Start()
    {
        pointer = GameObject.Find("Pointer");
        hasAdded = false;
    }

    public void Update()
    {
        Movement move = pointer.GetComponent<Movement>();
        if (!hasAdded)
        {  
            move.currentPos += addToPos;
            hasAdded = true;
        }      
    }

    public void Right()
    {
        addToPos = new Vector3(1, 0, 0);
        hasAdded = false;
    }

    public void Left()
    {
        addToPos = new Vector3(-1, 0, 0);
        hasAdded = false;
    }

    public void Up()
    {
        addToPos = new Vector3(0, 1, 0);
        hasAdded = false;
        debugTestNum += 1;
        Debug.Log(debugTestNum);
    }

    public void Down()
    {
        addToPos = new Vector3(0, -1, 0);
        hasAdded = false;
    }

    public void DUR()
    {
        addToPos = new Vector3(1, 1, 0);
        hasAdded = false;
    }

    public void DUL()
    {
        addToPos = new Vector3(-1, 1, 0);
        hasAdded = false;
    }

    public void DDR()
    {
        addToPos = new Vector3(1, -1, 0);
        hasAdded = false;
    }

    public void DDL()
    {
        addToPos = new Vector3(-1, -1, 0);
        hasAdded = false;
    }

}
