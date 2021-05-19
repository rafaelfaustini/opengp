using System;
using System.Collections.Generic;

public class TimedEventManager : IEventManager, IEventManagerConfigurator
{
    public List<TimedEvent> Events { get; set; }

    public TimedEventManager()
    {
        Events = new List<TimedEvent>();
    }

    public void Add(TimedEvent timedEvent)
    {
        Events.Add(timedEvent);
    }

    public void RunEvents(DateTime currentTime)
    {
        foreach (TimedEvent timedEvent in Events)
        {
            if (timedEvent.ShouldRun(currentTime))
            {
                timedEvent.Run();
            }
        }
    }
}
