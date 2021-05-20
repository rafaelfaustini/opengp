using System;

public abstract class TimeHandler
{
    private DateTime lastDateTime;

    protected TimeHandler(DateTime currentDateTime)
    {
        if (lastDateTime.Equals(null)) lastDateTime = currentDateTime;
    }

    public abstract bool ShouldHandle(DateTime currentDateTime, DateTime lastDateTime);

    public bool Handle(DateTime currentDateTime)
    {
        if (ShouldHandle(currentDateTime, lastDateTime))
        {
            lastDateTime = currentDateTime;
            return true;
        }
        return false;
    }
}

