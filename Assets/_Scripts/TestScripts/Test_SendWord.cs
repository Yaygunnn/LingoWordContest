using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SendWord : MonoBehaviour
{
    [SerializeField] private string Realword;
    [SerializeField] private string word;
    [SerializeField] private bool SendWord;

    private void Update()
    {
        Realword = WordData.Instance.GetWord();
        if (SendWord)
        {
            SendWord = false;
            if (WordGiver.Instance.TryToSendWord(word))
            {
                word = null;
            }
        }
    }
}
