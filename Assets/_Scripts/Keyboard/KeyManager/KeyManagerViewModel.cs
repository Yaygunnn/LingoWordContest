using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyManagerViewModel : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] public KeyboardModel KeyboardModel;

    [SerializeField] public RectTransform rectTransform;

    [SerializeField] public TextMeshProUGUI textMeshProUGUI;


    [Header("Transform")]
    [Range(0f, 1f)]
    [SerializeField] public float widthPercentage;
    [Range(0f, 0.2f)]
    [SerializeField] public float heightPercentage;
    [Range(0f, 0.1f)]
    [SerializeField] public float bottomOffset;
    [Range(-0.5f, 0.5f)]
    [SerializeField] public float LeftOffset;
}
