using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundData : MonoBehaviour
{
    public static BackGroundData Instance { get; private set; }
   

    [SerializeField] private BackgroundData[] Sprites;

    private int SelectedBackGroundIndex = 0;

    private void Awake()
    {
        Instance = this;
    } 
    public void SetBackGroundIndex(int index)
    {
        if (Array.IndexOf(Sprites, index) != -1)
        {
            SelectedBackGroundIndex = index;
        }
    }
    public Sprite GetBackGroundImage()
    {
        return Sprites[SelectedBackGroundIndex].backgroundSprite;
    }
}
