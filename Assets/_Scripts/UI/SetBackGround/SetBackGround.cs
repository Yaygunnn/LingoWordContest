using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBackGround : MonoBehaviour
{

    void Start()
    {
        Image image = GetComponent<Image>();
        image.sprite = BackGroundData.Instance.GetBackGroundImage();
    }


}
