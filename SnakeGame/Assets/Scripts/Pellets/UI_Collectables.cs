using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Collectables : MonoBehaviour
{

    [SerializeField] private UnityEngine.UI.Text collectableText;
    [SerializeField] private UnityEngine.UI.Image CollectabelImage;
    [SerializeField] private so_CollectableController Controller;
    [SerializeField] private so_PlayerEvents PlayerEvents;

    private void OnEnable()
    {
        PlayerEvents.OnHitCollectable += UpdateUI;
        
        string fillMessage = 0 + "%";
        
        if (collectableText != null)
        {
            collectableText.text = fillMessage;
        }
    }

    private void Start()
    {
        SetImageFillAmount(GetNormlisedFillAmount());
    }

    private void UpdateUI(Collectable obj)
    {
        SetImageFillAmount(GetNormlisedFillAmount());
        SetText(GetNormlisedFillAmount());
    }

    float GetNormlisedFillAmount()
    {
        float currentCollectables = Controller.GetCurrentCollectableCount();
        float totalcollectables = Controller.GetMaxCount();
        return currentCollectables / totalcollectables * 1.0f;
    }

    void SetText(float amount)
    {
        float fillamount = 1 - amount;
        fillamount = Mathf.Round(fillamount * 100);
        string fillMessage = fillamount.ToString() + "%";
        
        if (collectableText != null)
        {
            collectableText.text = fillMessage;
        }
    }

    void SetImageFillAmount(float amount)
    {
        float fillamount = 1 - amount;
        if (CollectabelImage != null)
        {
            CollectabelImage.fillAmount = fillamount;
        }
    }
}
