using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PlayerBar : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image bar;
    [SerializeField] private float count = 0;
    [SerializeField] private float maxCount;

    private void OnEnable()
    {
        UpdateFillAmount();
    }

    public void AddCount()
    {
        count++;
    }

    public void ResetCount()
    {
        count = 0;
        UpdateFillAmount();
    }

    public bool CountCheck()
    {
        return count >= maxCount;
    }

    public void UpdateFillAmount()
    {
        bar.fillAmount = count / maxCount * 1.0f;
    }
}
