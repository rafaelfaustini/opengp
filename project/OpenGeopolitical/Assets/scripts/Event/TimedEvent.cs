using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimedEvent : IEvent
{
    private DateTime nextDateTime;
    private readonly TimeSpan interval;
    protected TimedEvent(DateTime initialDate, TimeSpan interval)
    {
        this.interval = interval;
        this.nextDateTime = initialDate;
    }
    public void Run() {
        actuallyRun();
        nextDateTime = nextDateTime.Add(interval);
    }
    public abstract void actuallyRun();
    public bool ShouldRun(DateTime currentTime)
    {
        return currentTime == nextDateTime;
    }


}
