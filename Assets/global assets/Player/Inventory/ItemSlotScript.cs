using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Variables
    [SerializeField] Image icon; // item icon to be shown in Inventory
    [SerializeField] TextMeshProUGUI label; // name of the item to be shown in Inventory
    public GameObject referenceObj; // reference to the actual object for removal purposes
    [HideInInspector] public bool empty;
    [HideInInspector] public Transform ParentAfterDrag;
    [HideInInspector] public Vector3 PositionAfterDrag;
    [HideInInspector] private int SlotPosition;

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("beginDrag");
        ParentAfterDrag = transform.parent;
        PositionAfterDrag = transform.position;
        // SlotPosition = transform.GetSiblingIndex();
        transform.SetParent(transform.parent.parent.parent);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("endDrag");
        transform.SetParent(ParentAfterDrag);
        transform.position = PositionAfterDrag;
        // transform.SetSiblingIndex(SlotPosition);
    }
}
