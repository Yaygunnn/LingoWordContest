using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreatorModel : MonoBehaviour
{
    [SerializeField] public GameObject FirstGridCell;

    [SerializeField] public GameObject SecondGridCell;

    [HideInInspector] public float DistanceBetweenCells;

    [HideInInspector] public int WordLength;
    
}
