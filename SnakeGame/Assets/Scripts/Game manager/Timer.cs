using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private List<PlayerCharactor> players;
    private float _timeCounter;
    private float _counter;
    public float gameLength;
    [SerializeField] private float decreaseTimeAmount;
    [SerializeField] private so_PlayerEvents eventsSystem;
    public int timeTillTick;
    private bool _isTimerRunning;
    public UnityEngine.UI.Text textGameLength;
    public UnityEngine.UI.Image timerImage;
    
    
    private void Start()
    {
        _counter = 0;
        _timeCounter = gameLength;
        _isTimerRunning = true;
        SetText(_timeCounter);
        SetImageFillAmount();
    }

    void FixedUpdate()
    {

        _counter += Time.smoothDeltaTime;

        if (_counter >= timeTillTick)
        {
            _counter = 0;
            _timeCounter -= decreaseTimeAmount;
            
            if (_timeCounter > 0)
            {
                SetText(_timeCounter);
                SetImageFillAmount();
            }
            else
            {
                SetText(0);
            }
            
            if (_timeCounter < 0 && _isTimerRunning)
            {
                _isTimerRunning = false;
                eventsSystem.GameOver(players[0].GetCollectables(), true);
                eventsSystem.HitWall();
            }
            
        }
    }

    

    void SetText(float currentTime)
    {
        textGameLength.text = currentTime.ToString();
    }

    float GetNormalizedTime()
    {
        return _timeCounter / gameLength * 1f;
    }

    void SetImageFillAmount()
    {
        timerImage.fillAmount = GetNormalizedTime();
    }
}
