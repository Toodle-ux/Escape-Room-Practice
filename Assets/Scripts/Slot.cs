using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject inventory;

    public enum property { usable, displayable, empty };
    public property ItemProperty { get; set; }

    private string displayImage;
    public string CombinationItem { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("inventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.GetComponent<Inventory>().previousSelectedSlot = inventory.GetComponent<Inventory>().currentSelectedSlot;
        inventory.GetComponent<Inventory>().currentSelectedSlot = this.gameObject;

        if (inventory.GetComponent<Inventory>().previousSelectedSlot != null)
        {
            Combine();
        }

    }

    public void AssignProperty(int orderNumber, string displayImage, string CombinationItem)
    {
        ItemProperty = (property)orderNumber;
        this.displayImage = displayImage;
        this.CombinationItem = CombinationItem;
    }

    public void DisplayItem()
    {
        inventory.GetComponent<Inventory>().ItemDisplayer.SetActive(true);
        inventory.GetComponent<Inventory>().ItemDisplayer.GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/" + displayImage);
    }

    void Combine()
    {
        if (inventory.GetComponent<Inventory>().previousSelectedSlot.GetComponent<Slot>().CombinationItem
            == this.gameObject.GetComponent<Slot>().CombinationItem
            && this.gameObject.GetComponent<Slot>().CombinationItem != "")
        {
            Debug.Log("combine");
            var combinedItem = Instantiate(Resources.Load<GameObject>("Combined Items/" + CombinationItem));
            ClearSlot();
            combinedItem.GetComponent<PickUpItem>().ItemPickUp();
        }
    }

    public void ClearSlot()
    {
        ItemProperty = property.empty;
        displayImage = "";
        CombinationItem = "";
        inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/empty_item");
        inventory.GetComponent<Inventory>().previousSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/empty_item");
    }
}
