using System.Collections.Generic;

public interface IEventManagerConfigurator
{
    public List<TimedEvent> Events { get; set; }
    public void Add(TimedEvent timedEvent);
}
