using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    public static DateTime CurrentDateTime { get; private set; }
    public static bool IsPaused { get; private set; }

    private float minuteToRealTime = 0.00001736f; // 15 seconds per day
    private float timer;
    // Start is called before the first frame update

    public static void Pause()
    {
        IsPaused = true;
    }

    public static void UnPause()
    {
        IsPaused = false;
    }
    void Start()
    {
        CurrentDateTime = new DateTime(DateTime.Now.Year, 1, 1); // For testing it starts the game in the beginning of your year
        timer = minuteToRealTime;
        IsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPaused)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                CurrentDateTime = CurrentDateTime.AddMinutes(1);
                OnMinuteChanged?.Invoke();
                if (CurrentDateTime.Minute == 0)
                {
                    OnHourChanged?.Invoke();
                }

                   timer = minuteToRealTime;
            }
        }
    }
}
