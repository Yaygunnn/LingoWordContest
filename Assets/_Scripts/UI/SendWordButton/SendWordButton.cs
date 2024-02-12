using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendWordButton : MonoBehaviour
{
    private bool IsPlayerTurn = false;

    private void OnEnable()
    {
        EventManager.Instance.EventStartPlayerTurn += StartPlayerTurn;
        EventManager.Instance.EventWordInputGiven += EndPlayerTurn;
    }

    private void OnDisable()
    {
        EventManager.Instance.EventStartPlayerTurn -= StartPlayerTurn;
        EventManager.Instance.EventWordInputGiven -= EndPlayerTurn;
    }

    public void OnButtonClicked()
    {
        if(IsPlayerTurn)
        {
            KeyManagerController.Instance.TryToSendWord();
            EndPlayerTurn();
        }      
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
