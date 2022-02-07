using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private DisplayImage currentDisplay;

   

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();

    }

    // Update is called once per frame
    void Update()
    {
        // 如果按了左键
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 100);

            // 如果有物体&物体的tag是Interactable
            if (hit && hit.transform.tag == "Interactable")
            {
                // 调取IInteractable组件，把currentDisplay传入Interact方法
                hit.transform.GetComponent<IInteractable>().Interact(currentDisplay);
            }
        }
    }
}
