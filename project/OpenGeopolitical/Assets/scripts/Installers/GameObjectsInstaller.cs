using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameObjectsInstaller : MonoInstaller
{
    public Text textoTempo;
    public Button pauseButton;
    public Button fastForwardButton_one;
    public Button fastForwardButton_two;
    public Button fastForwardButton_three;
    public Sprite[] pauseSprites;
    public Sprite[] fastforwardSprites;

    public override void InstallBindings()
    {
        Container.Bind<TimedEventManager>().FromInstance(new TimedEventManager());
        Container.Bind<TimeManager>().FromInstance(new TimeManager(DateTime.Parse("01/01/2021"), 15));
        TimeUI timeUI = new TimeUI();
        timeUI.timeText = textoTempo;
        timeUI.pauseButton = pauseButton;
        timeUI.pauseSprites = pauseSprites;
        timeUI.fastforwardSprites = fastforwardSprites;
        timeUI.fastForwardButton_one = fastForwardButton_one;
        timeUI.fastForwardButton_two = fastForwardButton_two;
        timeUI.fastForwardButton_three = fastForwardButton_three;
        Container.Bind<TimeUI>().FromInstance(timeUI);

    }
}