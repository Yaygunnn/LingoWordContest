using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerController : MonoBehaviour
{
    [SerializeField] private GridManagerModel model;

    public static GridManagerController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
