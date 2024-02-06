using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotScript : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null)
        {
            if (transform.childCount == 0)
            {

                GameObject dropped = eventData.pointerDrag;
                PotionScript Potion = dropped.GetComponent<PotionScript>();
                Potion.ParentAfterDrag = transform;
            }

        }
        

    }

}
