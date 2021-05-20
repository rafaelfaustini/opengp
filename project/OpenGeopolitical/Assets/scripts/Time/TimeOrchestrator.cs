using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TimeOrchestrator : MonoBehaviour
{
    TimedEventManager timedEventManager;
    TimeManager timeManager;
    TimeUI timeUI;
    TimeHandler timeHandler;

    [Inject]
    public void Construct(TimedEventManager timedEventManager, TimeManager timeManager, TimeUI timeUI, TimeHandler timeHandler)
    {
        this.timedEventManager = timedEventManager;
        this.timeManager = timeManager;
        this.timeUI = timeUI;
        this.timeHandler = timeHandler;
        FastForward_1X();
    }


    // Update is called once per frame
    void Update()
    {
        if(timeManager.HandleFrame(Time.deltaTime)) timeUI.UpdateTime(timeManager.CurrentDateTime);
        if (timeHandler.Handle(timeManager.CurrentDateTime))
        {
            timedEventManager.RunEvents(timeManager.CurrentDateTime);
        }
    }

    public void Pause()
    {
        if (timeUI.IsPaused.Equals(0))
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
