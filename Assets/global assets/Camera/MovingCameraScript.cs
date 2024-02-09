using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCameraScript : MonoBehaviour
{
    [HideInInspector] public bool BoxBorderLeft = false;
    [HideInInspector] public bool BoxBorderRight = false;
    [HideInInspector] public bool BoxBorderUp = false;
    [HideInInspector] public bool BoxBorderDown = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player").gameObject;
    }


    void FixedUpdate()
    {
        if (BoxBorderLeft == true)
        {
            transform.position += new Vector3(-1 * player.GetComponent<PlayerScript>().moveSpeed * Time.deltaTime, 0, 0);
        }
        
        if (BoxBorderRight == true)
        {
            transform.position += new Vector3(1 * player.GetComponent<PlayerScript>().moveSpeed * Time.deltaTime, 0, 0);
        }
        
        if (BoxBorderUp == true) 
        {
            transform.position += new Vector3(0, 1 * player.GetComponent<PlayerScript>().moveSpeed * Time.deltaTime, 0);
        }
        
        if (BoxBorderDown == true) 
        {
            transform.position += new Vector3(0, -1 * player.GetComponent<PlayerScript>().moveSpeed * Time.deltaTime, 0);
        }
        
    }
}
