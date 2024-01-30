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

    private void Start()
    {
        EventManager.Instance.EventWordInputGiven += WriteWordToGrid;
    }

    public void SetGridCell(LetterCellController letterCellController, int xLeftToRight, int yTopToBottom)
    {
        model.LetterGrid[yTopToBottom, xLeftToRight] = letterCellController;
    }

    private void WriteWordToGrid(string word)
    {
        for(int letter = 0; letter < word.Length; letter++)
        {
            model.LetterGrid[model.CurrentGridLine, letter].WriteLetter(word[letter]);
        }
    }
}
