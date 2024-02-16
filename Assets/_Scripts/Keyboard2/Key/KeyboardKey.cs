using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyboardKey : MonoBehaviour
{
    private char key;
    void Start()
    {
        ReadKeyFromTextMeshProAndSetKey();
    }

    public void ButtonClicked()
    {
        KeyManagerController.Instance.KeyPressed(key);
    }
    private void ReadKeyFromTextMeshProAndSetKey()
    {
        key = GetComponentInChildren<TextMeshProUGUI>().text[0];
        key = char.ToLower(key);
    }
}
