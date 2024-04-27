using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Variables
    public float moveSpeed = 1; // Move Speed multiplier, can be altered in Inspector
    private Rigidbody2D rb2d;
    public float timer;
    public GameObject PopUpBox;
    public Canvas Canvas;


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>(); // Gets reference to rigidbody component
        timer = Random.Range(25, 76);
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

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (Canvas.transform.childCount < 3)
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0.0f)
            {
                Instantiate(PopUpBox, Canvas.transform);
                timer = Random.Range(25, 76);

            }
        }
        else
        {
            MainManagerScript MainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
            if (MainManager.BlewUp && Canvas.transform.childCount < 3) 
            {
                Instantiate(PopUpBox, Canvas.transform);
            }
        }
        
    }
}
