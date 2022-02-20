using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour, IInteractable
{
    public string DisplaySprite;
    public enum property { usable, displayable};

    public property itemProperty;

    public string DisplayImage;

    private GameObject InventorySlots;

    public void Interact(DisplayImage currentDisplay)
    {
        ItemPickUp();
    }

    // Start is called before the first frame update
    void Start()
    {
        InventorySlots = GameObject.Find("slots");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ItemPickUp()
    {
        foreach(Transform slot in InventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);
                slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayImage);
                Destroy(this.gameObject);
                break;
            }
        }
    }


}
