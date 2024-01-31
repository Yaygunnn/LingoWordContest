using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerView : MonoBehaviour
{
    [SerializeField] private GridManagerController controller;
    [SerializeField] private GridManagerModel model;
    private GridManagerViewModel viewModel = new GridManagerViewModel();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PaintGridRowWithAnim( int GridRow)
    {
        StartCoroutine(PaintGridRowIEnumerator(GridRow));

    }

    private void PaintGrindCellWithAnim(int GridRow, int GridCol)
    {
        model.LetterGrid[GridRow, GridCol].controller.SetGridState(model.LetterGrid[GridRow, GridCol].cellState);
    }

    private IEnumerator PaintGridRowIEnumerator(int GridRow)
    {
        if (viewModel.PaintRowWaitTimeStart > viewModel.PaintRowWaitTimeEveryLetter)
        {
            yield return new WaitForSecondsRealtime(viewModel.PaintRowWaitTimeStart - viewModel.PaintRowWaitTimeEveryLetter);
        }

        for(int i = 0; i<model.LetterGrid.GetLength(1);i++)
        {
            yield return new WaitForSecondsRealtime(viewModel.PaintRowWaitTimeEveryLetter);
            
            model.LetterGrid[GridRow, i].controller.SetGridState(model.LetterGrid[GridRow,i].cellState);
        }

        yield return new WaitForSecondsRealtime(viewModel.PaintRowWaitTimeEnd);

        controller.FinishedWriting();
    }
}
