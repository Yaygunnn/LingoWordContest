using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
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
        Invoke("GoNextTurn", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log("Victory");
    }
    private void Defeat()
    {
        Debug.Log("Defeat");
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

    private void OnDisable()
    {
        EventManager.Instance.EventEndOfTurn -= DecideEndOfTurn;
    }
}
