using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    public Button pauseButton;
    [SerializeField]
    private Sprite[] pauseSprites;
    public Text timeText;
    public int isPaused { get; set; }


    private void UpdateTime()
    {
        timeText.text = $"{TimeManager.Hour:00}:{TimeManager.Minute:00}";
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
    }
    private void OnDisable()
    {
        TimeManager.OnMinuteChanged -= UpdateTime;
        TimeManager.OnHourChanged -= UpdateTime;
    }

}
