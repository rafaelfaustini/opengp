using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute { get; private set; }

    public static int Hour { get; private set; }

    public static bool IsPaused { get; private set; }

    private float minuteToRealTime = 0.5f;
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
        Minute = 0;
        Hour = 0;
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
                Minute++;
                OnMinuteChanged?.Invoke();
                if (Minute >= 60)
                {
                    Hour++;
                    Minute = 0;
                    OnHourChanged?.Invoke();
                }

                timer = minuteToRealTime;
            }
        }
    }
}
