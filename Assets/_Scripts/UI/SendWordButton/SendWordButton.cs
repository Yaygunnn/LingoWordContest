using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendWordButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        KeyManagerController.Instance.TryToSendWord();
    }
}
