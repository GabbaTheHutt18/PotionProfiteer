using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotScript : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] GameObject referenceObj;
    public bool empty;
    
    public void Set(GameObject item)
    {
        icon.color = new Vector4(255f, 255f, 255f, 255f);
        icon.sprite = item.GetComponent<InventoryItem>().icon;
        label.text = item.GetComponent<InventoryItem>().displayName;
        referenceObj = item;
        empty = false;
    }

    public void Reset()
    {
        icon.color = new Vector4(0f, 0f, 0f, 0f);
        label.text = "Empty";
        referenceObj = null;
        empty = true;
    }
    void Start()
    {
        Reset();
    }
}
