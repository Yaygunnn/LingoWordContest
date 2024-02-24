using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMainGrid : MonoBehaviour
{
    [SerializeField] private LetterCellController letterCellController;

    [SerializeField] float Spacing;

    private void Start()
    {
        GridData grid = new GridData();

        grid.CellPrefab = letterCellController;

        grid.HorizontalLength = WordData.Instance.LetterNumber;

        grid.VerticalLength = GameConstans.GridHight;

        grid.Spacing = Spacing;

        grid.SendGridData = GridManagerController.Instance.SetGridCell;

        GridCreation.CreateGrid(grid);
    }
}
