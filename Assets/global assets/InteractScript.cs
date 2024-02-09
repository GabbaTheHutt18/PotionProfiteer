using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private bool InArea = false;
    private bool col = false;
    void Update()
    {
        if (InArea ==  true && Input.GetKeyDown(KeyCode.E))
        {
            Interaction();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InArea = false;
        }
    }

    void Interaction()
    {
        Debug.Log("Interaction!");
        if (col == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            col = true;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            col = false;
        }
        
    }
}
