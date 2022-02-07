using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    public enum State
    {
        normal, zoom, ChangedView
    };

    public State CurrentState { set; get; }

    public int CurrentWall
    {
        get { return currentWall; }
        set
        {
            // wall4的右边是wall1
            if (value == 5)
            {
                currentWall = 1;
            }
            else if (value == 0)
            {
                currentWall = 4;
            }
            else
            {
                currentWall = value;
            }
        }
    }

    private int currentWall;
    private int previousWall;

    private void Start()
    {
        previousWall = 0;
        currentWall = 1;
    }

    private void Update()
    {
        if (previousWall != currentWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWall.ToString());
        }

        previousWall = currentWall;
    }
}
