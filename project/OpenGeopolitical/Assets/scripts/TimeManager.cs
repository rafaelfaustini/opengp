using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    public static Action OnDayChanged;
    public static Action OnMonthChanged;


    public static DateTime CurrentDateTime { get; private set; }
    public static bool IsPaused { get; private set; }

    public float dayToRealTime = 15f; // 15 seconds per day
    private static float baseminuteToRealTime;
    private static float minuteToRealTime;
    private static int multiplier;

    private float timer;
    public void Awake()
    {
        QualitySettings.vSyncCount = 1;
    }
    public static void Pause()
    {
        IsPaused = true;
    }

    public static void UnPause()
    {
        IsPaused = false;
    }

    public static void FastForward(int _multiplier)
    {
        multiplier = _multiplier;
        minuteToRealTime = baseminuteToRealTime / _multiplier;
    }
    void Start()
    {
        CurrentDateTime = new DateTime(DateTime.Now.Year, 1, 1); // For testing, it starts the game in the beginning of your year
        minuteToRealTime = (dayToRealTime * 60) / 86400;
        baseminuteToRealTime = minuteToRealTime;
        timer = minuteToRealTime;
        IsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime beforeTimeChanged;
        if (!IsPaused)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                beforeTimeChanged = CurrentDateTime;
                CurrentDateTime = CurrentDateTime.AddMinutes(1*multiplier);
                OnMinuteChanged?.Invoke();
                if (CurrentDateTime.Hour != beforeTimeChanged.Hour)
                {
                    OnHourChanged?.Invoke();
                    if (CurrentDateTime.Day != beforeTimeChanged.Day)
                    {
                        OnDayChanged?.Invoke();
                        if (CurrentDateTime.Month != beforeTimeChanged.Month)
                        {
                            OnMonthChanged?.Invoke();
                        }
                    }
                }
                   timer = minuteToRealTime;
            }
        }
    }
}
