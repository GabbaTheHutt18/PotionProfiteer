using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> HandBag = new List<GameObject>(); // List of items in handbag
    private GameObject grid; // The parent that contains the slots in a grid
    private bool visible = false; // Toggle to define if the canvas is visible or not
    
    public void AddItem(GameObject item) // Add's item to Inventory UI
    {
        int childnum = grid.transform.childCount;
        GameObject gridspace = grid.transform.GetChild(0).gameObject; // Starts at the first child
        HandBag.Add(item);
        for (int i = 0; i < childnum; i++) //Runs through the children to find the next one that's empty (using a bool inicator on the shildren)
        {
            Transform reference = grid.transform.GetChild(i);
            if (reference.GetComponent<ItemSlotScript>().empty == true)
            {
                gridspace = reference.transform.gameObject;
                i = childnum; // ends loop early when an empty slot is found
            }
            
        }
        gridspace.GetComponent<ItemSlotScript>().Set(item); // allocates item to selected grid slot

        
    }

    public void RemoveItem(GameObject item)
    {
        // Work in progress
    }
    
    void ToggleInventoryVisibility() // Moves the grid to be in or out of frame depending on visibility toggle
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
    
    
    void Start()
    {
        grid = GameObject.Find("INV_Grid"); // reference to parent
        visible = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // Toggles visibility
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
