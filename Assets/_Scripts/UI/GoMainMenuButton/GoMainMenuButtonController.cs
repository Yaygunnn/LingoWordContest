using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMainMenuButtonController : MonoBehaviour
{
    public void GoToMainMenu()
    {
        LevelChanger.Instance.LoadStartMenu();
    }
}
