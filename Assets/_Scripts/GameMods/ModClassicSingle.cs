using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModClassicSingle : MonoBehaviour
{
    public static ModClassicSingle Instance { get; private set; }

    private ClassicSingleModel model = new ClassicSingleModel();

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        EventManager.Instance.EventEndOfTurn += DecideEndOfTurn;
        EventManager.Instance.SetFuncIsResultVictory(IsVictory);
        EventManager.Instance.NewRound();
        Invoke("GoNextTurn", 0.5f);
    }

    private void OnDisable()
    {
        EventManager.Instance.EventEndOfTurn -= DecideEndOfTurn;
        EventManager.Instance.UnSetFuncIsResultVictory(IsVictory);

    }

    private bool IsVictory()
    {
        return model.IsVictory;
    }

    private void DecideEndOfTurn()
    {
        switch (EventManager.Instance.RecieveWordAnswer())
        {
            case E_WordAnswer.Correct:
                Victory();
                break;
            case E_WordAnswer.TryAgain:
                TryAgain();
                break;
            case E_WordAnswer.Fail:
                Defeat();
                break;
            default:
                break;
        }        
    }

    private void TryAgain()
    {
        if (HaveTrialAttempts())
        {
            GoNextTurn();
            return;
        }
        Defeat();
    }
    private void Victory()
    {
        model.IsVictory = true;
        EventManager.Instance.Victory();
    }
    private void Defeat()
    {
        model.IsVictory = false;
        EventManager.Instance.Defeat();
    }
    private bool HaveTrialAttempts()
    {
        return model.TrialAttempts != 0;
    }

    private void GoNextTurn()
    {
        model.TrialAttempts--;
        EventManager.Instance.PrepareNextTurn();
    }

    
}
