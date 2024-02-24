using UnityEngine;
using System;
public class GridData 
{
    public LetterCellController CellPrefab;

    public int HorizontalLength;
    
    public int VerticalLength;
       
    public float Spacing;
    
    public Action<LetterCellController,int,int> SendGridData;
}
