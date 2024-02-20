using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCellController : MonoBehaviour
{
    [SerializeField] private LetterCellModel model;

    private void Start()
    {
        SetGridState(E_CellState.Standart);
    }

    public void WriteAndShowState(char letter)
    {
        WriteLetter(letter);
        SetGridState(E_CellState.True);
    }
    public void WriteLetter(char letter)
    {
        model.textMestPro.text = letter.ToString().ToUpper();
    }

    public void SetLetterCellFast(E_CellState state, char letter)
    {
        WriteLetter(letter);
        SetGridState(state);
    }
    public void SetGridState(E_CellState cellState)
    {
        switch (cellState)
        {
            case E_CellState.Standart:
            SetSprite(model.StandartSprite);
            break;
        case E_CellState.True:
            SetSprite(model.TrueSprite);
            break;
        case E_CellState.False:
            SetSprite(model.FalseSprite);
            break;
        case E_CellState.MissPlaced:
            SetSprite(model.MissPlaceSprite);
            break;
        default:
            break;
        }
    }
    private void SetSprite(Sprite sprite)
    {
        model.image.sprite = sprite;
    }

}
