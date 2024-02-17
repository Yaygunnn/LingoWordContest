using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Profiling.HierarchyFrameDataView;

public class TimerController : MonoBehaviour
{
    private TimerModel model = new TimerModel();
    [SerializeField] private TimerView view;
    
    void Start()
    {
        EventManager.Instance.EventWordRecieved += StopTimer;
        EventManager.Instance.EventStartPlayerTurn += StartTimer;
    }

    private void StartTimer()
    {
        StartCoroutine(Timer(model.CountDown));
        StartCoroutine(TimerFloatVersion(model.CountDown));
    }

    private void StopTimer(string word)
    {
        StopAllCoroutines();
    }
    private IEnumerator Timer(int time)
    {
        view.TimeChanged(time);
        while (time > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            time--;
            view.TimeChanged(time);
        }

        EventManager.Instance.WordInputGiven(" ");
       
    }

    private void OnDisable()
    {
        EventManager.Instance.EventWordRecieved -= StopTimer;
        EventManager.Instance.EventStartPlayerTurn -= StartTimer;
    }

    private IEnumerator TimerFloatVersion(int time)
    {
        float MiniTime = (float)time;
        float InitialTime = MiniTime;
        while(time > 0)
        {
            MiniTime -= Time.deltaTime;
            EventManager.Instance.RemainingTimeRatio(MiniTime / InitialTime);
            yield return null;
        }
    }
}
