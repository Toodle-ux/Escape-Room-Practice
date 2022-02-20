using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour, IInteractable
{
    public string UnlockItem;

    private GameObject inventory;

    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            Debug.Log("unlock");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("inventory"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
