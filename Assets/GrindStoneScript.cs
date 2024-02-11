using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GrindStoneScript : MonoBehaviour, IDropHandler
{
    GameObject dropped = null;
    ItemScript DragDrop;
    public TMP_Text ButtonText;
    public bool started = false;
    public bool pressed;
    public float mash;
    public float mashDelay = 1.5f;
    public float maximum = 50;
    public float current;
    public Image mask;
    public Sprite Seeds;
    // Start is called before the first frame update
    void Start()
    {

        mash = mashDelay;
    }

    // Update is called once per frame
    void Update()
    {      
        if (transform.childCount == 1 && started) 
        {
            mash -= Time.deltaTime/2;
            if (Input.GetKeyDown(KeyCode.X) && !pressed)
            {
                pressed = true;
                mash += mashDelay;
            }
            else if(Input.GetKeyUp(KeyCode.X))
            {
                pressed = false;
            }
            if (mash <= 0)
            {
                Debug.Log("Failed");
            
            }
            if(mash >= maximum) {
                started = false;
                transform.GetChild(0).gameObject.GetComponent<ItemScript>().Plantable = true;
                transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Seeds;
            
            }
        
        }
        getCurrentFill();


    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {

            dropped = eventData.pointerDrag;
            DragDrop = dropped.GetComponent<ItemScript>();
            DragDrop.ParentAfterDrag = transform;
        }

    }

    void getCurrentFill()
    {
        float fillAmount = mash / maximum;
        mask.fillAmount = fillAmount;
    
    }

    public void BeginButtonMash() { 
        if (started)
        {
            started = false;
            ButtonText.text = "Begin";
            mash = mashDelay;
        }
        else
        {
            started = true;
            ButtonText.text = "Stop";
            
        }
    
    }
}
