using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SendWord : MonoBehaviour
{
    [SerializeField] private string Realword;
    [SerializeField] private string word;
    [SerializeField] private bool SendWord;

    private void Start()
    {
        Debug.Log("Word list length is " + WordData.Instance.WordList.Count);
    }
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
