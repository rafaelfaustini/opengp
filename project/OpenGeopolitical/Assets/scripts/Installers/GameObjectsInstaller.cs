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

    public TimeUI MountTimeUI()
    {
        TimeUI timeUI = new TimeUI();
        timeUI.timeText = textoTempo;
        timeUI.pauseButton = pauseButton;
        timeUI.pauseSprites = pauseSprites;
        timeUI.fastforwardSprites = fastforwardSprites;
        timeUI.fastForwardButton_one = fastForwardButton_one;
        timeUI.fastForwardButton_two = fastForwardButton_two;
        timeUI.fastForwardButton_three = fastForwardButton_three;
        return timeUI;
    }

    public TimedEventManager MountTimedEventManager()
    {
        TimedEventManager timedEventManager = new TimedEventManager();
        DateTime initialDate = DateTime.Parse("01/01/2021");
        TimeSpan timeSpan = TimeSpan.FromDays(30);
        TestEvent testEvent = new TestEvent(initialDate, timeSpan);
        timedEventManager.Add(testEvent);
        return timedEventManager;
    }

    public override void InstallBindings()
    {
        Container.Bind<TimedEventManager>().FromInstance(MountTimedEventManager());
        Container.Bind<TimeManager>().FromInstance(new TimeManager(DateTime.Parse("01/01/2021"), 15));

        Container.Bind<TimeUI>().FromInstance(MountTimeUI());

    }
}