using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

[Serializable]
public class ScenarioEditor : MonoBehaviour
{
    private ScenarioBasicDetailsUI basicDetailsUI;

    [Inject]
    public void Construct(ScenarioBasicDetailsUI basicDetailsUI)
    {
        this.basicDetailsUI = basicDetailsUI;
    }

    public void Save()
    {
        Scenario scenario = new Scenario(basicDetailsUI.GetBasicDetails());
        HandleSaveScenario handler = new HandleSaveScenario();
        handler.Handle(scenario);
    }
}
