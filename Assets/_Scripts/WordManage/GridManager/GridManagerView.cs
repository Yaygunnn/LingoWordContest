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

    public void ShowFirstLetter()
    {
        StartCoroutine(PaintFirstLetter());
    }
    public void ShowGridHasBeenCarriedOneLineUp()
    {
        for(int x = 0; x < model.LetterGrid.GetLength(0);x++)
        {
            for(int y = 0; y< model.LetterGrid.GetLength(1); y++)
            {
                model.LetterGrid[x, y].controller.SetLetterCellFast(model.LetterGrid[x, y].cellState, model.LetterGrid[x, y].letter);
            }
        }
    }
    public void PaintGridRowWithAnim( int GridRow)
    {
        StartCoroutine(PaintGridRowIEnumerator(GridRow));

    }

    private void PaintGrindCellWithAnim(int GridRow, int GridCol)
    {
        model.LetterGrid[GridRow, GridCol].controller.SetGridStateWithAnim(model.LetterGrid[GridRow, GridCol].cellState);
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

            PaintGrindCellWithAnim(GridRow, i);
        }

        yield return new WaitForSecondsRealtime(viewModel.PaintRowWaitTimeEnd);

        controller.FinishedPaintingRow();
    }

    private IEnumerator PaintFirstLetter()
    {
        if (model.CurrentGridLine == 0)
        {
            model.LetterGrid[model.CurrentGridLine, 0].controller.WriteAndShowState(WordData.Instance.GetWord()[0]);

        }
        else
        {
            foreach(var element in WordCheckController.Instance.GetFoundLetters())
            {
                model.LetterGrid[model.CurrentGridLine, element.Key].controller.SetLetterCellFast(E_CellState.True, element.Value);
            }
        }
        yield return new WaitForSecondsRealtime(viewModel.WaitTimeAfterFirstLetter);
        
        controller.FinishedPaintingFirstLetter();
    }
       
}
