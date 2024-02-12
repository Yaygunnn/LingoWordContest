using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCheckModel 
{
    public List<string> PreviousWordTrys = new List<string>();

    public E_WordAnswer wordAnswer;

    public E_CellState[] e_CellStates = new E_CellState[WordData.Instance.LetterNumber];
}
