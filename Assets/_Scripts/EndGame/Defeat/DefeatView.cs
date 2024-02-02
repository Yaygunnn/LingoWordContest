using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefeatView : MonoBehaviour
{
    [SerializeField] private GameObject EndResultPanel;

    [SerializeField] private TextMeshProUGUI textMestPro;

    private string DefeatText = "REZÝÝÝLLLLLLLL";
    public void ShowDefeat()
    {
        EndResultPanel.SetActive(true);
        textMestPro.text = DefeatText;
    }
}
