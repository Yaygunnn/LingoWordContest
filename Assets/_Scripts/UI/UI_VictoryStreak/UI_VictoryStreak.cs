using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_VictoryStreak : MonoBehaviour
{
    [SerializeField] private GameObject TextObject;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    private float ShowOldStreakTime = 1f;
    private float DeletestreakTime = 2f;
    private float ShowNewStreakTime = 2.5f;

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
        Invoke("ShowOldStreak", ShowOldStreakTime);
        Invoke("DeleteStreakText", DeletestreakTime);
        Invoke("ShowNewStreak", ShowNewStreakTime);      
    }

    private void ShowOldStreak()
    {
        TextObject.SetActive(true);
    }
    private void DeleteStreakText()
    {
        textMeshProUGUI.text = "";
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
