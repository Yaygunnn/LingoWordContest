using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController : MonoBehaviour
{
    [SerializeField] private VictoryView view;
    void Start()
    {
        EventManager.Instance.EventVictory += Victory;
    }

    private void OnDisable()
    {
        EventManager.Instance.EventVictory -= Victory;
    }
    private void Victory()
    {
        view.ShowVictory();
    }
}
