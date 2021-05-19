using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : TimedEvent
{
    public TestEvent(DateTime initialDate, TimeSpan timeSpan) : base(initialDate, timeSpan)
    {
    }
    public override void ActuallyRun()
    {
        var a = 2;
    }
}
