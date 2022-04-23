using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour, IInteractable
{
    public string DisplaySprite;
    public enum property { usable, displayable, empty};

    public property itemProperty;

    public string DisplayImage;

    public string CombinationItem;

    private GameObject InventorySlots;

    public void Interact(DisplayImage currentDisplay)
    {
        ItemPickUp();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemPickUp()
    {
        InventorySlots = GameObject.Find("slots");

        foreach (Transform slot in InventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);
                slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayImage, CombinationItem);
                Destroy(this.gameObject);
                break;
            }
        }
    }

    
}
