using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAssetReader : MonoBehaviour
{
    [SerializeField] private TextAssetsModel model;
    
    public static TextAssetReader Instance;

    private void Awake()
    {
        Instance = this;
    }

    public string[] GetWordArray(int letterNumber)
    {
        TextAsset textAsset = GetTextAsset(letterNumber);

        string[] lines = textAsset.text.Split('\n');

        lines = RemoveReturnCharacter(lines);

        return lines;
    }

    private string[] RemoveReturnCharacter(string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = lines[i].Replace("\r", "");
        }
        return lines;
    }

    private TextAsset GetTextAsset(int letterNumber)
    {
        return GetTxtHolder().GetTxtAsset(letterNumber);
    }

    private TxtHolder GetTxtHolder()
    {
        return model.txtHolderTurkish;
    }


}
