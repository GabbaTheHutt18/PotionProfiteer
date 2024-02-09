using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_Up : MonoBehaviour
{
    GameObject MainCam;
    Component MCScript;

    void Start()
    {
        MainCam = this.gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MainCam.GetComponent<MovingCameraScript>().BoxBorderUp = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MainCam.GetComponent<MovingCameraScript>().BoxBorderUp = false;
        }

    }
}
