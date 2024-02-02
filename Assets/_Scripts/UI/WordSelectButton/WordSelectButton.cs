using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordSelectButton : MonoBehaviour
{
    [SerializeField] private int nLetterWords;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        SetButtonText();
    }
    public void WordSelectButtonClicked()
    {
        EventManager.Instance.SelectLetterNumber(nLetterWords);
    }

    private void SetButtonText()
    {
        textMeshProUGUI.text = nLetterWords.ToString() + " Harfli";
    }
}
