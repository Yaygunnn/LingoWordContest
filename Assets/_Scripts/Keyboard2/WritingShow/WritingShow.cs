using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WritingShow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextMeshPro;

    private void OnEnable()
    {
        KeyManagerController.Instance.WritingChanged += ChangeText;
    }

    private void OnDisable()
    {
        KeyManagerController.Instance.WritingChanged -= ChangeText;

    }
    private void ChangeText(string text)
    {
        TextMeshPro.text = text;
    }
}
