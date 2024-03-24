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

        if (itemref != null) 
        {
            inventoryManager.RemoveItem(itemref);
            droppedItem.Reset();
            Debug.Log("Item Dropped!");
        }
        else
        {
            Debug.Log("twat");
        }
    }
}
