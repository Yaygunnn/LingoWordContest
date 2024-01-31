using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    
    public void TimeChanged(int time)
    {
        Debug.Log("Time : " + time);
    }
}
