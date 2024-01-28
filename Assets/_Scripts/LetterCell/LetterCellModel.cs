using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterCellModel : MonoBehaviour
{
    [SerializeField] public TMPro.TextMeshPro textMeshPro;

    [SerializeField] public Material EmptyMaterial;
    [SerializeField] public Material TrueMaterial;
    [SerializeField] public Material FalseMaterial;
    [SerializeField] public Material MissPlaceMaterial;

}
