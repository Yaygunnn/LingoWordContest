using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerView : MonoBehaviour
{
    [SerializeField] private GridManagerController controller;
    [SerializeField] private GridManagerModel model;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PaintGridRowWithAnim( int GridRow)
    {
        for (int i = 0; i < model.LetterGrid.GetLength(1); i++) 
        {
            PaintGrindCellWithAnim(GridRow, i);
        }
    }

    private void PaintGrindCellWithAnim(int GridRow, int GridCol)
    {
        model.LetterGrid[GridRow, GridCol].controller.SetGridState(model.LetterGrid[GridRow, GridCol].cellState);
    }
}
