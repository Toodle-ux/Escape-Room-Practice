using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public bool IsCompleted { get; private set; }
    private bool itemSpawn;

    public GameObject ClaimItem;

    private DisplayImage displayImage;

    private void Start()
    {
        itemSpawn = false;
        displayImage = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        IsCompleted = false;
    }

    private void Update()
    {
        if (IsCompleted && !itemSpawn)
        {
            var claimItem = Instantiate(ClaimItem, GameObject.Find("piece8").transform, false);
            claimItem.transform.localScale = new Vector3(15, 15, 15);
            itemSpawn = true;
        }

        HideDisplay();
        CompletePuzzle();
    }

    void HideDisplay()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }

        if (displayImage.CurrentState == DisplayImage.State.normal)
        {
            this.gameObject.SetActive(false);
        }
    }

    void CompletePuzzle()
    {
        var puzzlePieces = FindObjectsOfType<PuzzlePiece>();
        foreach (PuzzlePiece puzzlePiece in puzzlePieces)
        {
            if (int.Parse(puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1)) !=
                int.Parse(puzzlePiece.gameObject.GetComponent<Image>().sprite.name.ToString().Substring(puzzlePiece.gameObject.GetComponent<Image>().sprite.name.Length - 1)))
            {
                IsCompleted = false;
                return;
            }

            IsCompleted = true;
        }
    }

    
}
