using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TimeEventsInstaller : MonoInstaller
{
    public Text textoTempo;
    public Button pauseButton;
    public Button fastForwardButton_one;
    public Button fastForwardButton_two;
    public Button fastForwardButton_three;
    public Sprite[] pauseSprites;
    public Sprite[] fastforwardSprites;
    private const string initialDateString = "2022-01-01 00:00";
    private DateTime initialDate = DateTime.ParseExact(initialDateString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

    private TimeUI MountTimeUI()
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

    private TimedEventManager MountTimedEventManager()
    {
        TimedEventManager timedEventManager = new TimedEventManager();
        TimeSpan timeSpan = TimeSpan.FromDays(30);
        TestEvent testEvent = new TestEvent(initialDate, timeSpan);
        timedEventManager.Add(testEvent);
        return timedEventManager;
    }

    private TimeHandler MountTimeHandler()
    {
        return new DayHandler(initialDate);
    }

    public override void InstallBindings()
    {
        Container.Bind<TimedEventManager>().FromInstance(MountTimedEventManager());
        Container.Bind<TimeManager>().FromInstance(new TimeManager(initialDate, 15));
        Container.Bind<TimeHandler>().FromInstance(MountTimeHandler());
        Container.Bind<TimeUI>().FromInstance(MountTimeUI());

    }
}