﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject inventory;

    public enum property { usable, displayable, empty};
    public property ItemProperty { get; private set; }

    private string displayImage;

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
    }

    public void AssignProperty(int orderNumber, string displayImage)
    {
        ItemProperty = (property)orderNumber;
        this.displayImage = displayImage;
    }

    public void DisplayItem()
    {
        inventory.GetComponent<Inventory>().ItemDisplayer.SetActive(true);
        inventory.GetComponent<Inventory>().ItemDisplayer.GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/" + displayImage);
    }
}
