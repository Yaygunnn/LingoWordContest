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
        EventManager.Instance.EventWordInputGiven += WriteNewWordToGrid;
    }

    public void SetGridCell(LetterCellController letterCellController, int xLeftToRight, int yTopToBottom)
    {
        model.LetterGrid[yTopToBottom, xLeftToRight].controller = letterCellController;
    }

    private void WriteNewWordToGrid(string word)
    {
        WriteRow(word);

        SetGridRowLetterInfo(word);
        SetGridRowCellStateInfo(word);

        view.PaintGridRowWithAnim(model.CurrentGridLine);
    }

    public void FinishedWriting()
    {
        GoNextGridLine();
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

    private void SetGridRowCellStateInfo(string word)
    {
        E_CellState[] CellStates = WordCheckController.Instance.RecieveVisualInfo(word);
        for (int letter = 0; letter < word.Length; letter++)
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

    
}
