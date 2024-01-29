using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterCellModel : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textMestPro;
    [SerializeField] public Image image;

    [SerializeField] public Material StandartMaterial;
    [SerializeField] public Material TrueMaterial;
    [SerializeField] public Material FalseMaterial;
    [SerializeField] public Material MissPlaceMaterial;

}
