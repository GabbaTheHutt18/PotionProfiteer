using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandBag_DropBox : MonoBehaviour, IDropHandler
{
    [SerializeField] private InventoryManager inventoryManager;
    public void OnDrop(PointerEventData eventData) {

        ItemSlotScript droppedItem = eventData.pointerDrag.GetComponent<ItemSlotScript>();
        GameObject itemref = droppedItem.referenceObj;

<<<<<<< HEAD
        WagonManager wagonManager = GameObject.Find("TriggerBox-A").GetComponent<WagonManager>();


        if (Main == 0) 
=======
        if (itemref != null) 
>>>>>>> parent of ef3fa3d (Merge pull request #10 from GabbaTheHutt18/Merge_2-joe)
        {
            inventoryManager.RemoveItem(itemref);
            droppedItem.Reset();
            Debug.Log("Item Dropped!");
        }
        else
        {
<<<<<<< HEAD
            if (itemref != null && counter <= 15)
            {
                inventoryManager.RemoveItem(itemref, GameObject.Find("TriggerBox-A").transform, false);
                wagonManager.Transfer(itemref);
                droppedItem.Reset();
                counter++;
                
            }
            else
            {
                Debug.Log("Wagon is Full!");
            }
=======
            Debug.Log("twat");
>>>>>>> parent of ef3fa3d (Merge pull request #10 from GabbaTheHutt18/Merge_2-joe)
        }
    }
}
