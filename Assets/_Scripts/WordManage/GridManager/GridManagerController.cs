using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerController : MonoBehaviour
{
    [SerializeField] private GridManagerModel model;
    [SerializeField] private GridManagerView view;

    public static GridManagerController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventManager.Instance.EventWordRecieved += WriteNewWordToGrid;
        EventManager.Instance.EventPrepareNextTurn += ShowFirstLetter;
    }

    public void SetGridCell(LetterCellController letterCellController, int xLeftToRight, int yTopToBottom)
    {
        model.LetterGrid[yTopToBottom, xLeftToRight].controller = letterCellController;
    }

    private void ShowFirstLetter()
    {
        if (model.ReachedEndOfGrid)
        {
            CarryGridOneLineUp();
            view.ShowGridHasBeenCarriedOneLineUp();
        }
        view.ShowFirstLetter();
    }

    private void WriteNewWordToGrid(string word)
    {
       
        WriteRow(word);

        SetGridRowLetterInfo(word);
        SetGridRowCellStateInfo();

        view.PaintGridRowWithAnim(model.CurrentGridLine);
    }

    public void FinishedPaintingRow()
    {
        GoNextGridLine();
        EventManager.Instance.EndOfTurn();
    }

    public void FinishedPaintingFirstLetter()
    {
        EventManager.Instance.StartPlayerTurn();
    }


    private void WriteRow(string word)
    {
        for (int letter = 0; letter < word.Length; letter++)
        {
            model.LetterGrid[model.CurrentGridLine, letter].controller.WriteLetter(word[letter]);
        }
    }

    private void SetGridRowLetterInfo(string word)
    {
        for (int letter = 0; letter < word.Length; letter++)
        {
            model.LetterGrid[model.CurrentGridLine, letter].letter = word[letter];
        }
    }

    private void SetGridRowCellStateInfo()
    {
        E_CellState[] CellStates = WordCheckController.Instance.RecieveVisualInfo();
        for (int letter = 0; letter < WordData.Instance.LetterNumber; letter++)
        {
            model.LetterGrid[model.CurrentGridLine, letter].cellState = CellStates[letter];
        }
    }

    private void GoNextGridLine()
    {
        model.CurrentGridLine++;
        if (model.CurrentGridLine == GameConstans.GridHight)
        {
            model.CurrentGridLine--;
            model.ReachedEndOfGrid = true;
        }
    }

    private void CarryGridOneLineUp()
    {
        for (int row = 0; row < GameConstans.GridHight - 1; row++) 
        {
            for(int col = 0; col < model.LetterGrid.GetLength(1); col++)
            {
                model.LetterGrid[row, col].cellState = model.LetterGrid[row + 1, col].cellState;
                model.LetterGrid[row, col].letter = model.LetterGrid[row + 1, col].letter;
            }
        }
        for (int col = 0; col < model.LetterGrid.GetLength(1); col++)
        {
            EmptyCell(model.CurrentGridLine, col);
        }
    }

    private void EmptyCell(int row, int col)
    {
        model.LetterGrid[row, col].cellState = E_CellState.Standart;
        model.LetterGrid[row, col].letter = ' ';
    }

    private void OnDisable()
    {
        EventManager.Instance.EventWordRecieved -= WriteNewWordToGrid;
        EventManager.Instance.EventPrepareNextTurn -= ShowFirstLetter;
    }
}
