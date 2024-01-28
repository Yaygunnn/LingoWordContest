using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }


    public event Action<int> SelectLetterNumberClicked;
    private void Awake()
    {
        Instance = this;
    }
    

    public void SelectLetterNumber(int letterNumber)
    {
        SelectLetterNumberClicked?.Invoke(letterNumber);
    }
    
}
