using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagerController : MonoBehaviour
{    
    public static KeyManagerController Instance {  get; private set; }


    public Action<string> WritingChanged;

    public string Writing;


    public void KeyPressed(char key)
    {
        Writing += key;
        FireWritingChanged();
    }

    public void BackSpaceKeyPressed()
    {
        if(Writing.Length > 0)
        {
            Writing = Writing.Substring(0, Writing.Length - 1);
            FireWritingChanged();
        }
    }

    private void FireWritingChanged() { WritingChanged?.Invoke(Writing); }
}
