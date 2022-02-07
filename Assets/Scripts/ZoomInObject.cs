using UnityEngine;
using System.Collections;
using System;

public class ZoomInObject : MonoBehaviour, IInteractable
{
    public float ZoomRatio = .5f;

    public void Interact(DisplayImage currentDisplay)
    {
        Camera.main.orthographicSize *= ZoomRatio;
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
            Camera.main.transform.position.z);

        // ignore the raycast
        gameObject.layer = 2;

        currentDisplay.CurrentState = DisplayImage.State.zoom;

        ConstrainCamera();
    }

    // 解决在边缘点击可缩放物，图像会出现游戏外画面的问题
    void ConstrainCamera()
    {
        // half of the height of the game view
        var height = Camera.main.orthographicSize;
        var width = height * Camera.main.aspect;

        var cameraBounds = GameObject.Find("cameraBounds");

        // print(width);
        // print(cameraBounds.transform.position.x);
        /*if (Camera.main.transform.position.x + width > cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
        {
            Camera.main.transform.position += new Vector3(cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 - Camera.main.transform.position.x - width, 0, 0);
        }*/

        if (Camera.main.transform.position.x > width)
        {
            //Camera.main.transform.position += new Vector3(width - Camera.main.transform.position.x, 0, 0);
            Camera.main.transform.position = new Vector3(width, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }

        if (Camera.main.transform.position.x < -width)
        {
            // Camera.main.transform.position += new Vector3(-width - Camera.main.transform.position.x, 0, 0);
            Camera.main.transform.position = new Vector3(- width, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }

        if (Camera.main.transform.position.y > height)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, height, Camera.main.transform.position.z);
        }

        if (Camera.main.transform.position.y < -height)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, -height, Camera.main.transform.position.z);
        }
    }
}
