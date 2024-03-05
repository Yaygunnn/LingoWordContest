using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_VictoryStreak : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    private float ShowNewStreakTime = 2;

    private void OnEnable()
    {
        EventManager.Instance.EventDefeat += InvokeShowNewStreak;
        EventManager.Instance.EventVictory += InvokeShowNewStreak;
    }
    private void OnDisable()
    {
        EventManager.Instance.EventDefeat -= InvokeShowNewStreak;
        EventManager.Instance.EventVictory -= InvokeShowNewStreak;
    }
    private void Awake()
    {
        SetTestAccordingToStreak();
    }


    private void SetTestAccordingToStreak()
    {
        textMeshProUGUI.text = VictoryStreakRecorder.Instance.GetVictoryStreak().ToString();
    }

    private void InvokeShowNewStreak()
    {
        Invoke("ShowNewStreak", ShowNewStreakTime);
        
    }

    private void ShowNewStreak()
    {
        SetTestAccordingToStreak();
        PlayAnimAndMusic();
    }
    private void PlayAnimAndMusic()
    {
        switch (EventManager.Instance.IsResultVictory())
        {
            case true:
                Debug.Log("PlayVictoryMusic");
                break;
            case false:
                Debug.Log("PlayLoserMusic");
                break;
        }
    }
}
