using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }

    private GameObject slots;
    public GameObject ItemDisplayer { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        slots = GameObject.Find("slots");
        InitializeInventory();

        //currentSelectedSlot = slots.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        SelectSlot();
        HideDisplay();
    }

    void InitializeInventory()
    {
        ItemDisplayer = GameObject.Find("itemDisplayer");
        ItemDisplayer.SetActive(false);

        foreach (Transform slot in slots.transform)
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
                slot.GetComponent<Slot>().DisplayItem();
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }

    void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ItemDisplayer.SetActive(false);

            if(currentSelectedSlot != null)
            {
                if (currentSelectedSlot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
                {
                    currentSelectedSlot = previousSelectedSlot;
                }
            }
        }
    }
}
