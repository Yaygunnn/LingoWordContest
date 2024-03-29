using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManagerModel model;

    private static SoundManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            
            model = GetComponent<SoundManagerModel>();
        }
    }

    public static void CellStateSound(E_CellState cellState)
    {
        switch (cellState)
        {
            case E_CellState.True:
                model.CellTrueSound.Play(model.SFXAudioSource);
                break;
            default:
                break;
        }
    }
    
}
