using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerModel : MonoBehaviour
{
    [HideInInspector] public LetterCellController[,] LetterGrid = new LetterCellController[GameConstans.GridHight, WordData.Instance.LetterNumber];

    [HideInInspector] public int CurrentGridLine;
}
