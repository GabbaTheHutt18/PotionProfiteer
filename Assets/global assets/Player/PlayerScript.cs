using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Variables
    public float moveSpeed = 1; // Move Speed multiplier, can be altered in Inspector
    private Rigidbody2D rb2d;


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>(); // Gets reference to rigidbody component
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal")) // Axis will return 1, 0 or -1 for right, stationary and left respectively.
        {
            rb2d.position += new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0);
        }

        if (Input.GetButton("Vertical")) // Axis will return 1, 0 or -1 for up, stationary and down respectively.
        {
            rb2d.position += new Vector2(0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);
        }
    }
}
