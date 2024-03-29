using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerModel : MonoBehaviour
{
    [SerializeField] public AudioSource SFXAudioSource;


    [SerializeField] public AudioEvent CellTrueSound;
    [SerializeField] public AudioEvent CellStandartSound;
    [SerializeField] public AudioEvent CellFalseSound;
    [SerializeField] public AudioEvent CellMissPlacedSound;

}
