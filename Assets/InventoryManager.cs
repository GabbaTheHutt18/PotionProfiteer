using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> HandBag = new List<GameObject>();
    private GameObject grid;
    private bool visible = false;
    
    public void AddItem(GameObject item)
    {
        int childnum = grid.transform.childCount;
        GameObject gridspace = grid.transform.GetChild(0).gameObject;
        HandBag.Add(item);
        for (int i = 0; i < childnum; i++)
        {
            Transform reference = grid.transform.GetChild(i);
            if (reference.GetComponent<ItemSlotScript>().empty == true)
            {
                gridspace = reference.transform.gameObject;
                i = childnum;
            }
            
        }
        gridspace.GetComponent<ItemSlotScript>().Set(item);

        
    }

    public void RemoveItem(GameObject item)
    {
        
    }
    
    void ToggleInventoryVisibility()
    {
        GameObject gridElem = GameObject.Find("INV_Grid");

        if (visible == false)
        {
            gridElem.GetComponent<RectTransform>().localPosition = new Vector3(-690f, -4f, 0f);
            visible = true;
        }
        else if (visible == true)
        {
            gridElem.GetComponent<RectTransform>().localPosition = new Vector3(-1300f, -4f, 0f);
            visible = false;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("INV_Grid");
        visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventoryVisibility();
        }

        /* if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject x = GameObject.Find("Item Slot (1)");
            RemoveItem(x);
        } */
    }
}
