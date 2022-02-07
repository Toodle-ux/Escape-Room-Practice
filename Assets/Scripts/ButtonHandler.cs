using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private DisplayImage currentDisplay;

    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    private void Start()
    {
        // 找到displayImage这个game object上的DisplayImage组件（是一个 类）
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();

        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;
    }

    //按右键的时候，DisplayImage里的CurrentWall变量加一
    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }

    public void OnClickZoomReturn()
    {
        //GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.normal;

        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            currentDisplay.CurrentState = DisplayImage.State.normal;

            var zoomInObjects = FindObjectsOfType<ZoomInObject>();
            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }

        if (currentDisplay.CurrentState == DisplayImage.State.ChangedView)
        {
            currentDisplay.CurrentState = DisplayImage.State.normal;

            currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
        }
        
    }

    private void Update()
    {
        if (currentDisplay.CurrentState == DisplayImage.State.normal)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
