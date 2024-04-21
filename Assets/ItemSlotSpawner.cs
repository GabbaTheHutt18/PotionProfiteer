using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ItemSlotPrefab;
    [SerializeField] private GameObject DropBoxPointer;
    [SerializeField] private int slot_num;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < slot_num; i++)
        {
            GameObject newslot = Instantiate(ItemSlotPrefab, this.transform);
            newslot.transform.GetChild(0).GetComponent<ItemSlotScript>().DropBoxRef = DropBoxPointer;
        }

        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (0.7441f, (slot_num / 10f));
    }
}
