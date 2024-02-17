using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    [SerializeField] private Image image;

    private void OnEnable()
    {
        EventManager.Instance.EventRemainingTimeRatio += SetImageFilledAmount;
    }

    private void OnDisable()
    {
        EventManager.Instance.EventRemainingTimeRatio -= SetImageFilledAmount;
    }
    private void SetImageFilledAmount(float amount)
    {
        image.fillAmount = amount;
    }
}
