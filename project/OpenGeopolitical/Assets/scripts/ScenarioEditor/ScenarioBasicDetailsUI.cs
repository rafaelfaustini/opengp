using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioBasicDetailsUI
{
    public TMP_InputField NameField { get; set; }
    public TMP_InputField Description { get; set; }
    public TMP_InputField InitialDate { get; set; }
    private ScenarioBasicDetails _scenarioBasicDetails;
    public ScenarioBasicDetails BasicDetails { set; private get; }

    public ScenarioBasicDetailsUI(TMP_InputField nameField, TMP_InputField description, TMP_InputField initialDate, ScenarioBasicDetails basicDetails)
    {
        NameField = nameField;
        Description = description;
        InitialDate = initialDate;
        BasicDetails = basicDetails;
    }

    public ScenarioBasicDetails GetBasicDetails()
    {
        BasicDetails.Name = NameField.text;
        BasicDetails.Description = Description.text;
        DateTime _initialDate = DateTime.MinValue;
        DateTime.TryParse(InitialDate.text, out _initialDate);
        BasicDetails.InitialDate = _initialDate;
        return BasicDetails;
    }
}
