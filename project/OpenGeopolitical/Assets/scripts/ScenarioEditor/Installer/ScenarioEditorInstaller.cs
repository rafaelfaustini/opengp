using TMPro;
using UnityEngine;
using Zenject;

public class ScenarioEditorInstaller : MonoInstaller
{
    public TMP_InputField nameField;
    public TMP_InputField descriptionField;
    public TMP_InputField initialDateField;

    private ScenarioBasicDetailsUI MountScenarioBasicDetailsUI()
    {
        ScenarioBasicDetails scenarioBasicDetails = new ScenarioBasicDetails();
        ScenarioBasicDetailsUI scenarioBasicDetailsUI = new ScenarioBasicDetailsUI(nameField, descriptionField, initialDateField, scenarioBasicDetails);
        return scenarioBasicDetailsUI;
    }


    public override void InstallBindings()
    {
        //Container.Bind<ScenarioBasicDetailsUI>().FromInstance(MountScenarioBasicDetailsUI());
        Container.Bind<ScenarioBasicDetailsUI>().FromInstance(MountScenarioBasicDetailsUI()).AsSingle();
    }

}