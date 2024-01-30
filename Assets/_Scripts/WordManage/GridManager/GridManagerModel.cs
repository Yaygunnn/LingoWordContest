using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerModel : MonoBehaviour
{
    [HideInInspector] public S_LetterCell[,] LetterGrid = new S_LetterCell[GameConstans.GridHight, WordData.Instance.LetterNumber];

    [HideInInspector] public int CurrentGridLine;
}
