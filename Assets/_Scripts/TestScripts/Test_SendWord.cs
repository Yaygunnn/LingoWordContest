using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SendWord : MonoBehaviour
{
    [SerializeField] private string word;
    [SerializeField] private bool SendWord;

    private void Update()
    {
        if (SendWord)
        {
            SendWord = false;
            EventManager.Instance.WordInputGiven(word);
        }
    }
}
