using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryStreakRecorder 
{
    private static VictoryStreakRecorder instance;

    public static VictoryStreakRecorder Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new VictoryStreakRecorder();
            }
            return instance;
        }
    }

    private VictoryStreakData model;

    public VictoryStreakRecorder()
    {
        model = new VictoryStreakData();

        EventManager.Instance.EventVictory += AddVictory;
        EventManager.Instance.EventDefeat += AddDefeat;

    }

    private void AddVictory()
    {
        model.VictoryStreak++;
        Debug.Log(model.VictoryStreak);
    }

    private void AddDefeat()
    {
        model.VictoryStreak = 0;
        Debug.Log(model.VictoryStreak);

    }

    public int GetVictoryStreak()
    {
        return model.VictoryStreak;
    }
}
