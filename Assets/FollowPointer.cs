using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointer : MonoBehaviour
{

    public Transform pointer;
    public bool sliderCanMove;
    private bool samePos;

    void Start()
    {
        sliderCanMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (transform.position != pointer.transform.position)
            {
                sliderCanMove = true;
                samePos = false;
            }
        }

        if (transform.position == pointer.transform.position)
        {
            // Debug.Log("Pos match");
            samePos = true;
            sliderCanMove = false;
        }

        if (!samePos)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, pointer.position, 0.002f);
        }
    }
}
