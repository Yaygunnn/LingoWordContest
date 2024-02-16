using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackspaceKey : MonoBehaviour
{
    public void BackSpaceButtonClicked()
    {
        KeyManagerController.Instance.BackSpaceKeyPressed();
    }

}
