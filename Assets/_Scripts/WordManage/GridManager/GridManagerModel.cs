using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerModel : MonoBehaviour
{
    [HideInInspector] public LetterCellController[,] LetterGrid = new LetterCellController[WordData.Instance.LetterNumber, GameConstans.GridHight];

    [HideInInspector] public int CurrentGridLine;
}
