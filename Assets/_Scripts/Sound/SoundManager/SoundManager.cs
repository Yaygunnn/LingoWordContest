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
    #region CellState
    public static void CellStateSound(E_CellState cellState)
    {
        switch (cellState)
        {
            case E_CellState.True:
                model.CellTrueSound.Play(model.SFXAudioSource);
                break;
            case E_CellState.False:
                model.CellFalseSound.Play(model.SFXAudioSource);
                break;
            case E_CellState.Standart:
                model.CellStandartSound.Play(model.SFXAudioSource);
                break;
            case E_CellState.MissPlaced:
                model.CellMissPlacedSound.Play(model.SFXAudioSource);
                break;
            default:
                break;
        }
    }
    #endregion

    #region KeyBoard;
    public static void KeyPress()
    {
        model.KeyPress.Play(model.SFXAudioSource);
    }

    public static void KeyPressFail()
    {
        model.KeyPressFail.Play(model.SFXAudioSource);
    }

    public static void KeyDelete()
    {
        model.KeyDelete.Play(model.SFXAudioSource);
    }

    public static void KeyDeleteFail()
    {
        model.KeyDeleteFail.Play(model.SFXAudioSource);
    }
    #endregion
}
