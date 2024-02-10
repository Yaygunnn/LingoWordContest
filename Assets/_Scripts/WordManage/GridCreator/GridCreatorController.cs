using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreatorController : MonoBehaviour
{
    [SerializeField] GridCreatorModel model;
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateGrid()
    {
        CalculateModelValues();
        CreateLetterGrid();
        DestroyFirstandSecondGridCells();
    }
    public void CalculateModelValues()
    {
        model.DistanceBetweenCells = model.CellImageTransform.sizeDelta.x + model.CellSpaceing;

        model.CellScale = model.FirstGridCell.transform.localScale;

        model.WordLength = WordData.Instance.LetterNumber;

        model.GridHight = GameConstans.GridHight;        
    }

    
    private void CreateLetterGrid()
    {
        for(int i = 0; i< model.WordLength; i++)
        {
            for (int k = 0; k < model.GridHight; k++)
            {
                GameObject LetterCell = Instantiate(model.FirstGridCell, gameObject.transform);
                SetCellTransform(LetterCell, i, k);

                AddToGridManagerLetterGrid(LetterCell, i, k);
            }
        }
    }

    private void SetCellTransform(GameObject LetterCell, int x, int y)
    {
        LetterCell.transform.localPosition = CalculatePosition(x, y);
        LetterCell.transform.localScale = model.CellScale;
    }

    private Vector3 CalculatePosition(int x, int y)
    {
        Vector3 pos = Vector3.zero;
        pos.x = model.DistanceBetweenCells * (x + 0.5f - (float)model.WordLength / 2);
        pos.y = model.DistanceBetweenCells * ((float)model.GridHight / 2 - y - 0.5f);
        return pos;
    }
    private void DestroyFirstandSecondGridCells()
    {
        Destroy(model.FirstGridCell);        
    }

    private void AddToGridManagerLetterGrid(GameObject LetterCell, int xLeftToRight, int yTopToBottom)
    {
        LetterCellController letterCellController = LetterCell.GetComponent<LetterCellController>();
        GridManagerController.Instance.SetGridCell(letterCellController, xLeftToRight, yTopToBottom);
    }
}
