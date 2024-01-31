using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModClassicSingle : MonoBehaviour
{
    public static ModClassicSingle Instance { get; private set; }

    private ClassicSingleModel model = new ClassicSingleModel();

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        EventManager.Instance.EventEndOfTurn += DecideEndOfTurn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DecideEndOfTurn()
    {
        EventManager.Instance.PrepareNextTurn();
    }

    private void OnDisable()
    {
        EventManager.Instance.EventEndOfTurn -= DecideEndOfTurn;
    }
}
