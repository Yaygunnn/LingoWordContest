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
        model.TimerCoroutine = StartCoroutine(Timer(model.CountDown));
    }

    private void StopTimer(string word)
    {
        StopCoroutine(model.TimerCoroutine);
    }
    private IEnumerator Timer(int time)
    {
        while(time > 0)
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
}
