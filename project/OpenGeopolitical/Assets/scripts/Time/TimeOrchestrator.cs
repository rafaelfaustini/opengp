using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TimeOrchestrator : MonoBehaviour
{
    TimedEventManager timedEventManager;
    TimeManager timeManager;
    TimeUI timeUI;

    [Inject]
    public void Construct(TimedEventManager timedEventManager, TimeManager timeManager, TimeUI timeUI)
    {
        this.timedEventManager = timedEventManager;
        this.timeManager = timeManager;
        this.timeUI = timeUI;
        FastForward_1X();
        Pause();
    }


    // Update is called once per frame
    void Update()
    {
        timeManager.HandleFrame(Time.deltaTime);
        timeUI.UpdateTime(timeManager.CurrentDateTime);
        timedEventManager.runEvents(timeManager.CurrentDateTime);
    }

    public void Pause()
    {
        if (timeUI.isPaused.Equals(0))
        {
            timeUI.Pause();
            timeManager.Pause();
        } else
        {
            timeUI.UnPause();
            timeManager.UnPause();
        }
    }

    public void FastForward_1X()
    {
        timeUI.FastForward_1X();
        timeManager.FastForward(1);
    }

    public void FastForward_5X()
    {
        timeUI.FastForward_5X();
        timeManager.FastForward(5);
    }

    public void FastForward_20X()
    {
        timeUI.FastForward_20X();
        timeManager.FastForward(20);
    }


}
