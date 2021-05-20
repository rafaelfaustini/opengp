using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayHandler : TimeHandler
{
    public DayHandler(DateTime currentDateTime) : base(currentDateTime){}
    public override bool ShouldHandle(DateTime currentDateTime, DateTime lastDateTime)
    {
        return currentDateTime.Day != lastDateTime.Day;
    }
}
