using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonthHandler : TimeHandler
{
    public MonthHandler(DateTime currentDateTime) : base(currentDateTime){}
    public override bool ShouldHandle(DateTime currentDateTime, DateTime lastDateTime)
    {
        return currentDateTime.Month != lastDateTime.Month;
    }
}
