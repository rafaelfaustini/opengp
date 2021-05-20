using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourHandler : TimeHandler
{
    public HourHandler(DateTime currentDateTime) : base(currentDateTime){}
    public override bool ShouldHandle(DateTime currentDateTime, DateTime lastDateTime)
    {
        return currentDateTime.Hour != lastDateTime.Hour;
    }
}
