using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAutoMovement : MonoBehaviour
{
    private GameObject Follower;
    public Slider slider;
    private bool canSlide;
    [SerializeField] float slideSpeed = 0.1f;
    private bool forwards;
    public bool shouldPress;

    // Start is called before the first frame update
    void Start()
    {
        Follower = GameObject.Find("Follower");
        forwards = true;
        slider.value = 0;
        canSlide = false;
        shouldPress = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (slider.value > 0.25)
        {
            if (slider.value < 0.75)
            {
                shouldPress = true;
            }
            else
            {
                shouldPress = false;
            }
        }
        else
        {
            shouldPress = false;
        }

        FollowPointer FP = Follower.GetComponent<FollowPointer>();
        if (FP.sliderCanMove == true)
        {
            if (forwards)
            {
                slider.value += slideSpeed * Time.deltaTime;
            }
            else
            {
                slider.value -= slideSpeed * Time.deltaTime;
                if (slider.value == 0)
                {
                    forwards = true;
                }
            }

            if (slider.value == 1)
            {
                forwards = false;
            }
        }
        if (FP.sliderCanMove == false)
        {
            slider.value = 0;
        }

        if (shouldPress)
        {
            if (Input.GetButtonDown("Jump"))
            {
                FP.canMove = true;
            }
        }
        else if (!shouldPress)
        {
            FP.canMove = false;
        }


    }
}
