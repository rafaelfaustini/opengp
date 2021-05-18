using System;
using System.Collections.Generic;

public class TimedEventManager : IEventManager, IEventManagerConfigurator
{
    public List<TimedEvent> Events { get; set; }

    public void add(TimedEvent timedEvent)
    {
        Events.Add(timedEvent);
    }

    public void runEvents(DateTime currentTime)
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