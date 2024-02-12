using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGiver : MonoBehaviour
{
    private bool IsPlayerTurn = false;

    public static WordGiver Instance { get; private set; }

    [SerializeField] private WordGiverView view;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        EventManager.Instance.EventStartPlayerTurn += StartPlayerTurn;
        EventManager.Instance.EventWordInputGiven += EndPlayerTurn;
    }

    private void OnDisable()
    {
        EventManager.Instance.EventStartPlayerTurn -= StartPlayerTurn;
        EventManager.Instance.EventWordInputGiven -= EndPlayerTurn;

    }

    public bool TryToSendWord(string word)
    {
        if(IsPlayerTurn)
        {
            if(CheckWordLength(word))
            {
                EndPlayerTurn();
                EventManager.Instance.WordInputGiven(word);
                return true;
            }
            view.WrongNumberOfLetters();
        }
        return false;
    }

    public bool CheckWordLength(string word)
    {
        return WordData.Instance.LetterNumber == word.Length;
    }
    private void StartPlayerTurn()
    {
        IsPlayerTurn = true;
    }

    private void EndPlayerTurn()
    {
        IsPlayerTurn = false;
    }

    private void EndPlayerTurn(string str)
    {
        EndPlayerTurn();
    }

}
