using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEvent
{
    public bool ShouldRun(DateTime currentTime);
    public void Run();
}
