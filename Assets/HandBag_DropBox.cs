using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandBag_DropBox : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData) {
        if (eventData != null)
        {
            GameObject invman = transform.parent.parent.gameObject;
            Debug.Log("Item Dropped!");

            GameObject droppedItem = eventData.pointerDrag;
            ItemSlotScript dItemslot = droppedItem.GetComponent<ItemSlotScript>();
            GameObject itemref = dItemslot.referenceObj;

            invman.GetComponent<InventoryManager>().RemoveItem(itemref);
            dItemslot.Reset();
        }
    }
}
