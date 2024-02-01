using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGiver : MonoBehaviour
{
    private bool IsPlayerTurn = false;

    public static WordGiver Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        EventManager.Instance.EventStartPlayerTurn += StartPlayerTurn;
    }

    private void OnDisable()
    {
        EventManager.Instance.EventStartPlayerTurn -= StartPlayerTurn;
    }

    public bool TryToSendWord(string word)
    {
        if(IsPlayerTurn)
        {
            IsPlayerTurn = false;
            EventManager.Instance.WordInputGiven(word);
            return true;
        }
        return false;
    }
    private void StartPlayerTurn()
    {
        IsPlayerTurn = true;
    }
    
}
