using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagerController  
{    
    private static KeyManagerController instance;
    public static KeyManagerController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new KeyManagerController();
            }
            return instance;
        }
    }

    public Action<string> WritingChanged;

    public string Writing;


    public KeyManagerController()
    {
        EventManager.Instance.EventFirstTurnStart += SetWritingToEmpty;
    }
    public void KeyPressed(char key)
    {
        Writing += key;
        FireWritingChanged();
    }

    public void BackSpaceKeyPressed()
    {
        if(Writing.Length > 1)
        {
            Writing = Writing.Substring(0, Writing.Length - 1);
            FireWritingChanged();
        }
    }

    public void TryToSendWord()
    {
        if (WordGiver.Instance.TryToSendWord(Writing))
        {
            SetWritingToEmpty();
        }
    }

    private void SetWritingToEmpty()
    {
        Writing = WordData.Instance.GetWord().Substring(0, 1);
        FireWritingChanged() ;
    }

    private void FireWritingChanged() { WritingChanged?.Invoke(Writing); }
}
