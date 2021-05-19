using System;
using UnityEngine;

public class TimeManager
{

    public DateTime InitialDate { get; private set; }
    public DateTime CurrentDateTime { get; private set; }
    public static bool IsPaused { get; private set; }

    private float baseminuteToRealTime;
    private float minuteToRealTime;
    private int multiplier=1;

    private float timer;

    public TimeManager(DateTime InitialDate, float gameDayToRealSeconds)
    {
        CurrentDateTime = InitialDate;
        minuteToRealTime = (gameDayToRealSeconds * 60) / 86400;
        baseminuteToRealTime = minuteToRealTime;
        timer = minuteToRealTime;
        IsPaused = false;
    }

    public void Pause()
    {
        IsPaused = true;
    }

    public void UnPause()
    {
        IsPaused = false;
    }

    public void FastForward(int _multiplier)
    {
        multiplier = _multiplier;
        minuteToRealTime = baseminuteToRealTime / _multiplier;
    }

    public void HandleFrame(float frameInterval)
    {
        if (!IsPaused)
        {
            timer -= frameInterval;
            if (timer <= 0)
            {
                CurrentDateTime = CurrentDateTime.AddMinutes(1*multiplier);
                timer = minuteToRealTime;
            }
        }
    }
}
