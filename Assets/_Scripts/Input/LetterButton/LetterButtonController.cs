using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterButtonController : MonoBehaviour
{
    [SerializeField] private char Letter;
    [SerializeField] private TextMeshProUGUI textMestPro;
    void Start()
    {
        ShowLetter();
    }

    // Update is called once per frame
    public void ButtonClicked()
    {
        Debug.Log(Letter);
    }
    private void ShowLetter()
    {
        textMestPro.text=Letter.ToString();
    }
}
