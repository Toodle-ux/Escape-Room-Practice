using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }

    private GameObject slots;
    private GameObject itemDisplayer;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeInventory();
        slots = GameObject.Find("slots");
        itemDisplayer = GameObject.Find("itemDisplayer");
    }

    // Update is called once per frame
    void Update()
    {
        SelectSlot();
    }

    void InitializeInventory()
    {
        foreach(Transform slot in slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/empty_item");
        }
    }

    void SelectSlot()
    {
        foreach(Transform slot in slots.transform)
        {
            if(slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.usable)
            {
                slot.GetComponent<Image>().color = new Color(.9f, .4f, .6f, 1);
            }
            else if(slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
            {

            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
}
