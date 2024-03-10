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

    // Start is called before the first frame update
    void Start()
    {
        Follower = GameObject.Find("Follower");
        forwards = true;
        slider.value = 0;
        canSlide = false;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
