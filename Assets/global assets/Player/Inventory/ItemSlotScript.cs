using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotScript : MonoBehaviour
{
    // Variables
    [SerializeField] Image icon; // item icon to be shown in Inventory
    [SerializeField] TextMeshProUGUI label; // name of the item to be shown in Inventory
    [SerializeField] GameObject referenceObj; // reference to the actual object for removal purposes
    public bool empty;
    
    public void Set(GameObject item) // Sets the slot to inhabit/represent an item
    {
        icon.color = new Vector4(255f, 255f, 255f, 255f); // set opacity to full
        icon.sprite = item.GetComponent<InventoryItem>().icon; // sets sprite to stored icon
        label.text = item.GetComponent<InventoryItem>().displayName; // sets text to stored name
        referenceObj = item;
        empty = false;
    }

    public void Reset() // Sets the slot to its empty state
    {
        icon.color = new Vector4(0f, 0f, 0f, 0f); // set opacity to 0
        label.text = "Empty";
        referenceObj = null;
        empty = true;
    }
    void Start()
    {
        Reset();
    }
}
