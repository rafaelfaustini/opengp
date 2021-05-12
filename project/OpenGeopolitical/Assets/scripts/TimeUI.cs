using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    public Button pauseButton;
    [SerializeField]
    private Sprite[] pauseSprites;
    public Button fastForwardButton_one;
    public Button fastForwardButton_two;
    public Button fastForwardButton_three;
    [SerializeField]
    private Sprite[] fastforwardSprites;
    public Text timeText;
    public int isPaused { get; set; }

    public void FastForward_1X()
    {
        fastForwardButton_one.image.sprite = fastforwardSprites[1];
        fastForwardButton_two.image.sprite = fastforwardSprites[0];
        fastForwardButton_three.image.sprite = fastforwardSprites[0];
        TimeManager.FastForward(1);
    }

    public void FastForward_5X()
    {
        fastForwardButton_one.image.sprite = fastforwardSprites[1];
        fastForwardButton_two.image.sprite = fastforwardSprites[1];
        fastForwardButton_three.image.sprite = fastforwardSprites[0];
        TimeManager.FastForward(5);
    }

    public void FastForward_20X()
    {
        fastForwardButton_one.image.sprite = fastforwardSprites[1];
        fastForwardButton_two.image.sprite = fastforwardSprites[1];
        fastForwardButton_three.image.sprite = fastforwardSprites[1];
        TimeManager.FastForward(20);
    }

    private void UpdateTime()
    {
        string text = TimeManager.CurrentDateTime.ToString("ddd MMM dd yyyy HH:mm");
        timeText.text = text;
    }

    private void togglePauseSprite()
    {
        pauseButton.image.sprite = pauseSprites[isPaused];
    }
    public void Pause()
    {
        if (isPaused == 1)
        {
            TimeManager.UnPause();
            isPaused = 0;
            togglePauseSprite();
        } else
        {
            TimeManager.Pause();
            isPaused = 1;
            togglePauseSprite();
        }
    }

    private void OnEnable()
    {
        TimeManager.OnMinuteChanged += UpdateTime;
        TimeManager.OnHourChanged += UpdateTime;
        FastForward_1X();
    }
    private void OnDisable()
    {
        TimeManager.OnMinuteChanged -= UpdateTime;
        TimeManager.OnHourChanged -= UpdateTime;
    }

}
