using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFactory : MonoBehaviour
{
    private void Awake()
    {
        VictoryStreakRecorder.Instance.GetVictoryStreak();//To Instantiate StreakRecorder
    }
}
