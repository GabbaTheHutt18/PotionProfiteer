using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform ParentAfterDrag;
    public Image image;
    public int PlantType;
    public Sprite SpeedsSprite; 
    MainManagerScript mainManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        mainManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToSeeds()
    {
        image.sprite = SpeedsSprite;
        switch (PlantType)
        {
            case 0:
                mainManagerScript.ResourceInventory["firePlant"] -= 1;
                mainManagerScript.ResourceInventory["fireSeeds"] += 3;
                break;
            case 1:
                mainManagerScript.ResourceInventory["herbPlant"] -= 1;
                mainManagerScript.ResourceInventory["herbSeeds"] += 3;
                break;
            case 2:
                mainManagerScript.ResourceInventory["icePlant"] -= 1;
                mainManagerScript.ResourceInventory["iceSeeds"] += 3;
                break;
            case 3:
                mainManagerScript.ResourceInventory["cavePlant"] -= 1;
                mainManagerScript.ResourceInventory["caveSeeds"] += 3;
                break;
            default:
                break;
        }
        StartCoroutine(destroyObject());

    }

    IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;

        //text.SetActive(false);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAfterDrag);
        image.raycastTarget = true;

    }

}
