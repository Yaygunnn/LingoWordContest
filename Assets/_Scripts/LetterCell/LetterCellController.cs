using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCellController : MonoBehaviour
{
    [SerializeField] private LetterCellModel model;

    private void Start()
    {
        WriteLetter('a');
    }
    public void WriteLetter(char letter)
    {
        model.textMestPro.text = letter.ToString();
    }

    public void SetGridState(E_CellState cellState)
    {
        /*switch (cellState)
        {
            case E_CellState.Standart:
        
        }*/
    }
    
}
