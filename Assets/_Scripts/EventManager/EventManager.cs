using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager 
{
    private static EventManager instance;
    public static EventManager Instance 
    {
        get
        {
            if (instance == null)
            {
                instance = new EventManager();
            }
            return instance;
        }
    }


    #region Events
    public event Action<int> EventSelectLetterNumber;

    public event Action EventWordSelected;

    public event Action<string> EventWordRecieved;

    public event Action EventStartPlayerTurn;

    public event Action EventPrepareNextTurn;

    public event Action EventEndOfTurn;

    public event Action<string> EventWordInputGiven;

    public event Action EventVictory;

    public event Action EventDefeat;

    public event Action EventFirstTurnStart;

    public event Action<float> EventRemainingTimeRatio;

    public event Action<int> EventSetCountDownTime;

    public event Action EventNewRound;
    #endregion

    #region Funcs
    private Func<E_WordAnswer> FuncRecieveWordAnswer;

    private Func<bool> FuncIsResultVictory;

    #endregion
    
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

    public void Victory()
    {
        EventVictory?.Invoke();
    }

    public void Defeat()
    {
        EventDefeat?.Invoke();
    }

    public void FirstTurnStart()
    {
        EventFirstTurnStart?.Invoke();
    }

    public void RemainingTimeRatio(float timeRatio)
    {
        EventRemainingTimeRatio?.Invoke(timeRatio);
    }

    public void SetCountDownTime(int countDownTime)
    {
        EventSetCountDownTime?.Invoke(countDownTime);
    }

    public void NewRound()
    {
        EventNewRound?.Invoke();
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

    public void SetFuncIsResultVictory(Func<bool> func)
    {
        FuncIsResultVictory = func;
    }

    public bool IsResultVictory()
    {
        try
        {
            return FuncIsResultVictory();

        }
        catch (Exception ex)
        {
            Debug.Log(ex + "FuncIsResultVictory is not set");
        }

        return false;
    }

    public void UnSetFuncIsResultVictory(Func<bool> funci)
    {
        if (FuncIsResultVictory.GetInvocationList().Contains(funci))
        {
            FuncIsResultVictory = null;
        }
    }

    #endregion
}
