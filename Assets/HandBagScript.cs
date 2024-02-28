using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HandBagScript : MonoBehaviour
{
    //Variables
    public List<GameObject> HandBag = new List<GameObject>();
    private bool inReach = false;
    private int resInArea = 0;
    [SerializeField] List<GameObject> grabable = new List<GameObject>();
    public int HandBagLimit = 10;
    GameObject InvManager;

    // Start is called before the first frame update
    void Start()
    {
        InvManager = GameObject.Find("HB_Inventory");
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (resInArea == 0)
        {
            inReach = false;
        }

        if (inReach == true && Input.GetKeyDown(KeyCode.E))
        {
            if (this.gameObject.transform.childCount < HandBagLimit)
            {
                GameObject chosenElem = grabable[0];
                GameObject itemRef = chosenElem.gameObject;
                InvManager.GetComponent<InventoryManager>().AddItem(itemRef);
                chosenElem.transform.SetParent(this.gameObject.transform);
                chosenElem.gameObject.SetActive(false);
                grabable.Remove(chosenElem);
            }
            else
            {
                Debug.Log("HandBag is full!");
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log(HandBag);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            inReach = true;
            grabable.Add(collision.gameObject);
            resInArea++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            grabable.Remove(collision.gameObject);
            resInArea--;
        }
    }
}
