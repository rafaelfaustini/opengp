using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TimeUI
{
    public Button pauseButton;
    [SerializeField]
    public Sprite[] pauseSprites;
    public Button fastForwardButton_one;
    public Button fastForwardButton_two;
    public Button fastForwardButton_three;
    [SerializeField]
    public Sprite[] fastforwardSprites;
    public Text timeText;
    public int isPaused { get; set; }

    public void FastForward_1X()
    {
        fastForwardButton_one.image.sprite = fastforwardSprites[1];
        fastForwardButton_two.image.sprite = fastforwardSprites[0];
        fastForwardButton_three.image.sprite = fastforwardSprites[0];
    }

    public void FastForward_5X()
    {
        fastForwardButton_one.image.sprite = fastforwardSprites[1];
        fastForwardButton_two.image.sprite = fastforwardSprites[1];
        fastForwardButton_three.image.sprite = fastforwardSprites[0];
    }

    public void FastForward_20X()
    {
        fastForwardButton_one.image.sprite = fastforwardSprites[1];
        fastForwardButton_two.image.sprite = fastforwardSprites[1];
        fastForwardButton_three.image.sprite = fastforwardSprites[1];
    }

    public void UpdateTime(DateTime dateTime)
    {
        string text = dateTime.ToString("ddd MMM dd yyyy HH:mm");
        timeText.text = text;
    }

    private void togglePauseSprite()
    {
        pauseButton.image.sprite = pauseSprites[isPaused];
    }
    public void Pause()
    {
        isPaused = 1;
        togglePauseSprite();
    }
    public void UnPause()
    {
        isPaused = 0;
        togglePauseSprite();
    }
}
