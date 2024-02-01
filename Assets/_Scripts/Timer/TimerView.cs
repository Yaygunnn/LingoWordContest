using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerText;
    public void TimeChanged(int time)
    {
        WriteTime(time);
    }


    private void WriteTime(int time)
    {
        TimerText.text = time.ToString();
    }
}
