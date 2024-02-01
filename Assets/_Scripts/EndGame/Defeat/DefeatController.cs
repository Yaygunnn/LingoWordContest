using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatController : MonoBehaviour
{
    [SerializeField] private DefeatView View;
    void Start()
    {
        EventManager.Instance.EventDefeat += Defeat;
    }

    private void OnDisable()
    {
        EventManager.Instance.EventDefeat -= Defeat;
    }
    private void Defeat()
    {
        View.ShowDefeat();
    }
}
