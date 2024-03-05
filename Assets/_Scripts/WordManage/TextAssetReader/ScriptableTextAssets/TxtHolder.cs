using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Txt Holder", menuName = "Scriptable/Txt Holder", order = 1)]
public class TxtHolder : ScriptableObject
{
    [SerializeField] private TextAsset _4LetterTxtFile;
    [SerializeField] private TextAsset _5LetterTxtFile;
    [SerializeField] private TextAsset _6LetterTxtFile;

    public TextAsset GetTxtAsset(int letterNumber)
    {
        switch (letterNumber)
        {
            case 4: return _4LetterTxtFile;
            case 5: return _5LetterTxtFile;
            case 6: return _6LetterTxtFile;
            default: return null;
        }
    }

}
