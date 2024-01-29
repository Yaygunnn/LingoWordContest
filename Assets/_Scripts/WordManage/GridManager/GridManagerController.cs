using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerController : MonoBehaviour
{
    [SerializeField] private GridManagerModel model;

    public static GridManagerController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetGridCell(LetterCellController letterCellController, int xLeftToRight, int yTopToBottom)
    {
        model.LetterGrid[xLeftToRight, yTopToBottom] = letterCellController;
    }
}
