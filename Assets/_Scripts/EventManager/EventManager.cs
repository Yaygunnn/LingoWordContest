using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }


    public event Action<int> EventSelectLetterNumber;

    public event Action EventWordSelected;

    public event Action<string> EventWordInputGiven;

    public event Action EventStartPlayerTurn;

    public event Action EventPrepareNextTurn;

    public event Action EventEndOfTurn;
    private void Awake()
    {
        Instance = this;
    }

    public void EndOfTurn()
    {
        EventEndOfTurn?.Invoke();
    }
    public void PrepareNextTurn()
    {
        EventPrepareNextTurn?.Invoke();
    }
    public void StartPlayerTurn()
    {
        EventStartPlayerTurn?.Invoke();
    }

    public void SelectLetterNumber(int letterNumber)
    {
        EventSelectLetterNumber?.Invoke(letterNumber);
    }

    public void WordSelected()
    {
        EventWordSelected?.Invoke();
    }

    public void WordInputGiven(string word)
    {
        EventWordInputGiven?.Invoke(word);
    }
    
}
