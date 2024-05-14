using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryView : MonoBehaviour
{
    [SerializeField] private GameObject EndResultPanel;

    [SerializeField] private TextMeshProUGUI textMestPro;

    private string VictoryText = "iyisin iyi";
    
    public void ShowVictory()
    {
        EndResultPanel.SetActive(true);
        textMestPro.text = VictoryText;
    }
}
