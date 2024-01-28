using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCellController : MonoBehaviour
{
    [SerializeField] private LetterCellModel model;
    
    public void WriteLetter(char letter)
    {
        model.textMeshPro.text = letter.ToString();
    }

    
}
