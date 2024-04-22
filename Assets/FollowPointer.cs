using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointer : MonoBehaviour
{

    public Transform pointer;
    public bool sliderCanMove;
    private bool samePos;
    public MainManagerScript MainManager;
    public CircleCollider2D circleCollider;

    void Start()
    {
        MainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
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
                circleCollider.enabled = false;
            }
        }

        if (transform.position == pointer.transform.position)
        {
            // Debug.Log("Pos match");
            samePos = true;
            sliderCanMove = false;
            circleCollider.enabled = true;
        }

        if (!samePos)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, pointer.position, 0.002f);
        }
    }

    public void AddPotion()
    {
        Vector2 Potion = pointer.transform.position;
        MainManager.Potions.Add(new Potion(Potion));
        Debug.Log(Potion);
        foreach (var item in MainManager.Potions)
        {
            Debug.Log(item.PotionStats);
        }
    }
}
