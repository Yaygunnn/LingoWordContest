using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }


    #region Events
    public event Action<int> EventSelectLetterNumber;

    public event Action EventWordSelected;

    public event Action<string> EventWordRecieved;

    public event Action EventStartPlayerTurn;

    public event Action EventPrepareNextTurn;

    public event Action EventEndOfTurn;

    public event Action<string> EventWordInputGiven;
    #endregion

    #region Funcs
    private Func<E_WordAnswer> FuncRecieveWordAnswer;

    #endregion
    private void Awake()
    {
        Instance = this;
    }
    #region CallEvents
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

    public void WordRecieved(string word)
    {
        EventWordRecieved?.Invoke(word);
    }

    public void WordInputGiven(string word)
    {
        EventWordInputGiven?.Invoke(word);
    }
    #endregion

    #region Call&SetFuncs

    public void SetFuncRecieveWordAnswer(Func<E_WordAnswer> func)
    {
        FuncRecieveWordAnswer = func;
    }

    public E_WordAnswer RecieveWordAnswer()
    {
        try
        {
            return FuncRecieveWordAnswer();

        }catch (Exception ex)
        {
            Debug.Log(ex + "FuncRecieveWordAnswer is not set");
        }

        return E_WordAnswer.Fail;
    }

    public void UnSetFuncRecieveWordAnswer(Func<E_WordAnswer> funci)
    {
        if(FuncRecieveWordAnswer.GetInvocationList().Contains(funci))
        {
            FuncRecieveWordAnswer = null;
        }
    }

    #endregion
}
