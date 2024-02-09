using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Variables
    public float moveSpeed = 1;
    private Rigidbody2D rb2d;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal"))
        {
            rb2d.position += new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0);
        }

        if (Input.GetButton("Vertical"))
        {
            rb2d.position += new Vector2(0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);
        }
    }
}
