using System;

[Serializable]
public class Scenario
{
    public string Name;
    public string Description;
    public string InitialDate;

    public Scenario(ScenarioBasicDetails basicDetails)
    {
        Name = basicDetails.Name;
        Description = basicDetails.Description;
        InitialDate = basicDetails.InitialDate.ToString();
    }
}
