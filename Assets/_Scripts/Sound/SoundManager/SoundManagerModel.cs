using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerModel : MonoBehaviour
{
    [SerializeField] public AudioSource SFXAudioSource;

    [Header("Cell States")]
    [SerializeField] public AudioEvent CellTrueSound;
    [SerializeField] public AudioEvent CellStandartSound;
    [SerializeField] public AudioEvent CellFalseSound;
    [SerializeField] public AudioEvent CellMissPlacedSound;

    [Header("Key Press")]
    [SerializeField] public AudioEvent KeyPress;
    [SerializeField] public AudioEvent KeyPressFail;
    [SerializeField] public AudioEvent KeyDelete;
    [SerializeField] public AudioEvent KeyDeleteFail;

}
