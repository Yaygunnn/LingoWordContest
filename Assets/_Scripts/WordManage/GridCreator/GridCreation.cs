using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCreation : MonoBehaviour
{
    private static float CellSize;
    public static void CreateGrid(GridData gridData)
    {
        CreateLetterGrid(gridData);
    }

    private static void CreateLetterGrid(GridData gridData)
    {
        for (int i = 0; i < gridData.HorizontalLength; i++)
        {
            for (int k = 0; k < gridData.VerticalLength; k++)
            {
                LetterCellController LetterCell = Instantiate(gridData.CellPrefab, gridData.CellPrefab.gameObject.transform.parent.transform);
                
                SetCellTransform(gridData, LetterCell, i, k);

                SendGridData(gridData, LetterCell, i, k);
            }
        }
    }

    private static void SetCellTransform(GridData gridData, LetterCellController LetterCell, int x, int y)
    {
        CalculateGridSize(gridData);
        LetterCell.transform.localPosition = CalculatePosition(gridData, x, y);
        SetScale(gridData, LetterCell);
    }

    private static void SetScale(GridData gridData, LetterCellController cell)
    {
        cell.SetScale(CellSize);
    }
    private static Vector3 CalculatePosition(GridData gridData ,int x, int y)
    {
        float DistanceBetweenCells = CellSize + gridData.Spacing;
        Vector3 pos = gridData.CellPrefab.gameObject.transform.localPosition;
        pos.x += DistanceBetweenCells * (x + 0.5f - (float)gridData.HorizontalLength / 2);
        pos.y += DistanceBetweenCells * ((float)gridData.VerticalLength / 2 - y - 0.5f);
        return pos;
    }

    private static void SendGridData(GridData gridData, LetterCellController cell, int x, int y)
    {
        gridData.SendGridData(cell, x, y);
    }

    private static void CalculateGridSize(GridData gridData)
    {
        CellSize = gridData.CellPrefab.GetImageTransform().sizeDelta.x;
    }

}
