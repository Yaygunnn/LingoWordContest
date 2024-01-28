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
        model.DistanceBetweenCells = model.FirstGridCell.transform.localPosition.x - model.SecondGridCell.transform.localPosition.x;

        model.CellScale = model.FirstGridCell.transform.localScale;
        
        model.WordLength = 5;// must be change later

        model.GridHight = 5;//must be change later

        Debug.Log(model.DistanceBetweenCells);
        /*Debug.Log(model.CellScale);
        Debug.Log(model.WordLength);
        Debug.Log(model.GridHight);*/
    }

    
    private void CreateLetterGrid()
    {
        for(int i = 0; i< model.WordLength; i++)
        {
            for (int k = 0; k < model.GridHight; k++)
            {
                GameObject LetterCell = Instantiate(model.FirstGridCell, gameObject.transform);
                SetCellTransform(LetterCell, i, k);
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
        pos.x = /*(model.WordLength - 1) **/ model.DistanceBetweenCells * (x - model.WordLength / 2);
        pos.y =/* (model.GridHight - 1) **/ model.DistanceBetweenCells * (model.GridHight / 2 - y);
        Debug.Log(pos.x);
        return pos;
    }
    private void DestroyFirstandSecondGridCells()
    {
        Destroy(model.FirstGridCell);
        Destroy(model.SecondGridCell);
    }
}
